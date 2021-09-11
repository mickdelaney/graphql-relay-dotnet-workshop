import React, { FunctionComponent } from 'react';
import { Switch, Route, useRouteMatch, useLocation } from 'react-router-dom';
import {
  PhotographIcon,
  UserIcon,
  ViewGridIcon,
  LogoutIcon,
  CubeTransparentIcon,
} from '@heroicons/react/outline';
import { createLinkState, Shell } from '@workshop/ui';

import { GroupsLayout, AccountLayout, FeedLayout, ProfileLayout } from '../areas';

export const SecureLayout: FunctionComponent = () => {
  const { path, url } = useRouteMatch();
  const location = useLocation();

  const sidebarNavigation = [
    createLinkState(location, 'Account', `${url}/account`, ViewGridIcon),
    createLinkState(location, 'Groups', `${url}/groups`, PhotographIcon),
    createLinkState(location, 'Profile', `${url}/profile`, CubeTransparentIcon),
    createLinkState(location, 'Feed', `${url}/feed`, CubeTransparentIcon),
  ];

  const userNavigation = [
    { name: 'Your Profile', href: '#', icon: UserIcon, current: true },
    { name: 'Sign out', href: '#', icon: LogoutIcon, current: true },
  ];

  return (
    <Shell
      sidebarNavigation={sidebarNavigation}
      userNavigation={userNavigation}
    >
      <Switch>
        <Route exact path={path}>
          <div className='p-4'>
            <h3>Welcome to Workshop Network</h3>
          </div>
        </Route>
        <Route path={`${path}/groups`}>
          <GroupsLayout />
        </Route>
        <Route path={`${path}/account`}>
          <AccountLayout />
        </Route>
        <Route path={`${path}/feed`}>
          <FeedLayout />
        </Route>
        <Route path={`${path}/profile`}>
          <ProfileLayout />
        </Route>
      </Switch>
    </Shell>
  );
};
