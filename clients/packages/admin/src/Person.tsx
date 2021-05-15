import graphql from 'babel-plugin-relay/macro';
import { FunctionComponent } from "react";
import { useFragment } from "react-relay";
import { Person_person$key } from './__generated__/Person_person.graphql';

export interface PersonProps {
    person: Person_person$key;
}

const personFragment = graphql`
    fragment Person_person on Person {
        id
        name
        webSite
    }
`;

export const Person: FunctionComponent<PersonProps> = (props) => {
    const data = useFragment(personFragment, props.person);
    return (
        <div>{data.name}</div>
    )
}

export default Person;
