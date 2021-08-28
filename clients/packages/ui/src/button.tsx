/* eslint-disable no-alert */
import { meaningOfLife } from '@workshop/lib';
import React, { FunctionComponent } from "react";

type Props = {
  onClick?: () => void;
}

export const Button: FunctionComponent<Props> = ({ children  }) => {
  return (
    <button
      type="button"
      onClick={() => alert(`the meaning if life is ${meaningOfLife}`)}
    >
      Click me
    </button>
  )
}
