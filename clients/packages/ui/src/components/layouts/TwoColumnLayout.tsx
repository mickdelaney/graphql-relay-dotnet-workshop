import React, { FunctionComponent, JSXElementConstructor, ReactElement } from 'react';

type Props = {
  main: ReactElement<any, string | JSXElementConstructor<any>>;
  aside: ReactElement<any, string | JSXElementConstructor<any>>;
};

export const TwoColumnLayout: FunctionComponent<Props> = ({ main, aside }) => {
  return (
    <div className='flex-1 flex items-stretch overflow-hidden'>
      <main className='flex-1 overflow-y-auto'>
        {main}
      </main>
      <aside className='hidden w-96 bg-white border-l border-gray-200 overflow-y-auto lg:block'>
        {aside}
      </aside>
    </div>
  );
}