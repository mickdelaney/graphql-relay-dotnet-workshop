import React from 'react';
import { Location } from 'history';

export function createLinkState(
  location: Location,
  name: string,
  path: string,
  icon: any,
): LinkState {
  return {
    name: name,
    href: path,
    icon: icon,
    current: location.pathname === path,
  };
}

export type LinkState = {
  name: string;
  href: string;
  // eslint-disable-next-line no-unused-vars
  icon(props: React.ComponentProps<'svg'>): JSX.Element;
  current: boolean;
};
