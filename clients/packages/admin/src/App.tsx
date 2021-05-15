import React, {FunctionComponent, useState} from "react";
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

const { Suspense } = React;

const PeronNameQuery = graphql`
  query AppPersonQuery {
    ...PeopleList_people
  }
`;

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

  const [peopleConnectionId, setPeopleConnectionId] = useState<string>('');

  return (
    <div className="sm:w-1/2 m-auto m-8">
      <header className="text-blue-500 text-lg">People</header>

      <section className="my-4">
        <PeopleList people={query} setId={setPeopleConnectionId} />
      </section>
      <section className="my-4">
        <CreatePerson peopleConnectionId={peopleConnectionId} />
      </section>
    </div>
  );
};

export const AppRoot: FunctionComponent = () => {
  return (
    <RelayEnvironmentProvider environment={RelayEnvironment}>
      <Suspense fallback={"Loading..."}>
        <App preloadedQuery={preloadedQuery} />
      </Suspense>
    </RelayEnvironmentProvider>
  );
};

export default AppRoot;
