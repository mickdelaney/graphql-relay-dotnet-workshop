import { useContext } from 'react';
import type { AuthContextProps } from './AuthContextInterface';
import { AuthContext } from './AuthContext';

export const useAuth = () => {
  return useContext<AuthContextProps|null>(AuthContext);
};