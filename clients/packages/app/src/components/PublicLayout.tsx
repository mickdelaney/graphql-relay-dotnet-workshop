import React, { FunctionComponent } from 'react';

type PublicLayoutProps = {
}

export const PublicLayout: FunctionComponent<PublicLayoutProps> = ({ children  }) => {
  return (
    <div className='container'>
      <div className='m-8 border'>
        {children}
      </div>
    </div>
  );
}

export default PublicLayout;
