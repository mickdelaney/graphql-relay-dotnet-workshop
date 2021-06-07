import React, {FunctionComponent, useEffect, useState} from "react";
import { BrowserRouter, Switch, Route, Link } from "react-router-dom";
import graphql from "babel-plugin-relay/macro";
import {
  RelayEnvironmentProvider,
  loadQuery,
  usePreloadedQuery,
  PreloadedQuery,
} from "react-relay/hooks";
import { OperationType } from "relay-runtime";
import RelayEnvironment from "./RelayEnvironment";
import "./App.css";
import { AppPersonQuery } from "./__generated__/AppPersonQuery.graphql";
import { CreatePerson } from "./CreatePerson";
import PeopleList from "./PeopleList";

import config from "./config";
import { AuthProvider, useAuth } from "@mick/lib";
import { User } from "oidc-client";

const oidcConfig = {
  ...config,
  onSignIn: async (userData: User | null) => {
    window.location.hash = "";

    if (userData) {
      localStorage.setItem("authToken", userData.access_token);
    }
  },
};

const { Suspense } = React;

const PeronNameQuery = graphql`
  query AppPersonQuery {
    ...PeopleList_people
  }
`;

const Home = () => {

  return (
      <>
        <div>Home</div>
        <div className="flex items-center space-x-4">
          <Link to="/app">Go To App</Link>
          <Link to="/account">Go To Account</Link>
        </div>
      </>
  )
}

const Account = () => {

  const getToken = () => {
    const token = localStorage.getItem("authToken");

    if (!token) {
      return "";
    }

    return token;
  };

  useEffect(() => {
    async function fetchMyAPI() {
      const response = await fetch("https://localhost:5700/identity", {
        method: "GET",
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json",
          "authorization": `Bearer ${getToken()}`,
        }
      });
    }

    fetchMyAPI();
  }, []);



  return (
      <>
        <div>Account</div>
        <div className="flex items-center space-x-4">
          <Link to="/">Go To Home</Link>
          <Link to="/app">Go To App</Link>
        </div>
      </>
  )
}

const CurrentUser = () => {
  const auth = useAuth();
  if (auth && auth.userData) {
    return (
      <div>
        <p>Hi {auth?.userData?.profile?.ElevateAccountName}</p>
        <div className="flex items-center space-x-4">
          <Link to="/app">Go To App</Link>
          <button onClick={() => auth.signOut()}>Log out!</button>
        </div>
      </div>
    );
  }
  return <div>Not logged in! Try to refresh to be redirected to Google.</div>;
};

const preloadedQuery = loadQuery(RelayEnvironment, PeronNameQuery, {
  /* query variables */
});

export const App: FunctionComponent<{
  preloadedQuery: PreloadedQuery<OperationType>;
}> = (props: any) => {
  const query = usePreloadedQuery<AppPersonQuery>(
    PeronNameQuery,
    props.preloadedQuery
  );

  const [peopleConnectionId, setPeopleConnectionId] = useState<string>("");
  const changePeopleConnectionId = (id: string): void => {
    setPeopleConnectionId(id);
  };

  return (
    <div className="m-8 border">
      <div className="flex justify-between">
        <div>
          <header className="text-blue-500 text-lg">
            <div className="flex items-center space-x-4">
              <p>People</p>
              <Link to="/app">Go To Home</Link>
            </div>
          </header>

          <section className="my-4">
            <PeopleList people={query} setId={changePeopleConnectionId} />
          </section>
          <section className="my-4">
            <CreatePerson peopleConnectionId={peopleConnectionId} />
          </section>
        </div>
      </div>
    </div>
  );
};

export const AppRoot: FunctionComponent = () => {
  return (
    <AuthProvider {...oidcConfig}>
      <RelayEnvironmentProvider environment={RelayEnvironment}>
        <Suspense fallback={"Loading..."}>
          <BrowserRouter>
            <div className="container">
              <Switch>
                <Route path="/signin-oidc">
                  <CurrentUser />
                </Route>
                <Route path="/app">
                  <App preloadedQuery={preloadedQuery} />
                </Route>
                <Route path="/account">
                  <Account />
                </Route>
                <Route path="/">
                  <Home />
                </Route>
              </Switch>
            </div>
          </BrowserRouter>
        </Suspense>
      </RelayEnvironmentProvider>
    </AuthProvider>
  );
};

export default AppRoot;
