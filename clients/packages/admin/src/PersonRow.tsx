import graphql from 'babel-plugin-relay/macro';
import { FunctionComponent } from "react";
import { useFragment } from "react-relay";
import { PersonRow_person$key } from './__generated__/PersonRow_person.graphql';
import './PersonRow.css';

export interface PersonRowProps {
    person: PersonRow_person$key;
    callback:() => void;
}

const fragment = graphql`
    fragment PersonRow_person on Person {
        id
        name
        webSite
    }
`;

export const PersonRow: FunctionComponent<PersonRowProps> = (props) => {
    const data = useFragment(fragment, props.person);
    return (
        <div className='row' onClick={props.callback}>
            <div className='item'>{data.name}</div>
            <div className='item'>{data.webSite}</div>
        </div>
    )
}
