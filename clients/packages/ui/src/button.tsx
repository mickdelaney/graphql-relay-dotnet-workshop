/* eslint-disable no-alert */
import { meaningOfLife } from '@mick/lib';
import React, { FunctionComponent } from "react";

type Props = {
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
