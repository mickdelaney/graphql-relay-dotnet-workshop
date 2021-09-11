import React, { FunctionComponent, JSXElementConstructor, ReactElement } from 'react';

type Props = {
  label: ReactElement<any, string | JSXElementConstructor<any>>;
};

export const FormRow: FunctionComponent<Props> = ({ label, children }) => {
  return (
    <div className='grid grid-cols-3 gap-6'>
      <div className='col-span-3 sm:col-span-2'>
        {label}
        <div className='mt-1 flex rounded-md shadow-sm'>
          {children}
        </div>
      </div>
    </div>
  );
}