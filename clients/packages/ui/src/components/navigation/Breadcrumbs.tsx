import React, { FunctionComponent } from 'react';
import { HomeIcon } from '@heroicons/react/solid';

export type BreadcrumbLink = {
  name: string;
  href: string;
  current?: boolean;
};

type Props = {
  links: Array<BreadcrumbLink>;
};

export const Breadcrumbs: FunctionComponent<Props> = ({ links }) => {
  return (
    <nav className='flex' aria-label='Breadcrumb'>
      <ol role='list' className='flex items-center space-x-4'>
        <li>
          <div>
            <a href='#' className='text-gray-400 hover:text-gray-500'>
              <HomeIcon className='flex-shrink-0 h-5 w-5' aria-hidden='true' />
              <span className='sr-only'>Home</span>
            </a>
          </div>
        </li>
        {links.map(page => (
          <li key={page.name} className='flex'>
            <div className='flex items-center'>
              <svg
                className='flex-shrink-0 h-5 w-5 text-gray-300'
                xmlns='http://www.w3.org/2000/svg'
                fill='currentColor'
                viewBox='0 0 20 20'
                aria-hidden='true'
              >
                <path d='M5.555 17.776l8-16 .894.448-8 16-.894-.448z' />
              </svg>
              <a
                href={page.href}
                className='ml-4 text-sm font-medium text-gray-500 hover:text-gray-700'
                aria-current={page.current ? 'page' : undefined}
              >
                {page.name}
              </a>
            </div>
          </li>
        ))}
      </ol>
    </nav>
  );
};
