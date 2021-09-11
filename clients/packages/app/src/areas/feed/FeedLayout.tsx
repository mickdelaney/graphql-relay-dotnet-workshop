import { useAuth } from '@workshop/lib';
import React, { FunctionComponent } from 'react';

export const FeedLayout: FunctionComponent = () => {
  const auth = useAuth();
  if (auth && auth.userData) {
    return (
      <div>
        <p>Hi {auth?.userData?.profile?.ElevateAccountName}</p>
        <button onClick={() => auth.signOut()}>Log out!</button>
      </div>
    );
  }
  return <div>Not logged in! Try to refresh to be redirected to Google.</div>;
};
