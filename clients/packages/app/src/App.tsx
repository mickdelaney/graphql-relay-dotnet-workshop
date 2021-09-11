import React, { FunctionComponent } from 'react';
import { BrowserRouter, Route, Link } from 'react-router-dom';
import { RelayEnvironmentProvider } from 'react-relay/hooks';
import { User } from 'oidc-client';
import { AuthProvider } from '@workshop/lib';

import RelayEnvironment from './RelayEnvironment';
import './App.css';
import { SecureLayout } from './components';

import config from './config';

const oidcConfig = {
  ...config,
  onSignIn: async (userData: User | null) => {
    window.location.hash = '';

    if (userData) {
      localStorage.setItem('authToken', userData.access_token);
    }
  },
};

const { Suspense } = React;

export const AppRoot: FunctionComponent = () => {
  return (
    <AuthProvider {...oidcConfig}>
      <RelayEnvironmentProvider environment={RelayEnvironment}>
        <Suspense fallback={'Loading...'}>
          <BrowserRouter>
            <div className='container'>
              <Route path='/signin-oidc'>
                <Link to={`/app`}>Go To App</Link>
              </Route>
              <Route path='/app'>
                <SecureLayout />
              </Route>
              <Route path='/'>
                <h1>Workshop Network</h1>
              </Route>
            </div>
          </BrowserRouter>
        </Suspense>
      </RelayEnvironmentProvider>
    </AuthProvider>
  );
};

export default AppRoot;
