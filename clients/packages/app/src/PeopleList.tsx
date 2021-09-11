import { graphql } from 'react-relay/hooks';
import React, { FunctionComponent, useCallback, useEffect } from "react";
import { usePaginationFragment } from "react-relay";
import { PeopleList_people$key } from "./__generated__/PeopleList_people.graphql";
import { PersonRow } from "./PersonRow";
import { AppPersonQuery } from "./__generated__/AppPersonQuery.graphql";

export interface PeopleListProps {
  people: PeopleList_people$key;
  setId: (id: string) => void;
}

const peopleListFragment = graphql`
  fragment PeopleList_people on Query
  @argumentDefinitions(
    first: { type: Int, defaultValue: 1 }
    after: { type: String }
  )
  @refetchable(queryName: "PeopleListPaginationQuery") {
    people(first: $first, after: $after) @connection(key: "PeopleList_people") {
      __id
      pageInfo {
        hasNextPage
        hasPreviousPage
        startCursor
        endCursor
      }
      edges {
        node {
          id
          name
          webSite
          ...Person_person
          ...PersonRow_person
        }
        cursor
      }
    }
  }
`;

function log() {
  console.log(`called from child`);
}

export const PeopleList: FunctionComponent<PeopleListProps> = (props) => {
  const { data, loadNext, isLoadingNext } = usePaginationFragment<
    AppPersonQuery,
    PeopleList_people$key
  >(peopleListFragment, props.people);

  const { people } = data;

  useEffect(() => {
    if (people?.__id) {
      props.setId(people?.__id);
    }
  }, [props, people]);

  const rows = people?.edges?.map((person) => {
    return (
      <li className="flex items-center space-x-4" key={person.node.id}>
        <PersonRow person={person.node} callback={log} />
      </li>
    );
  });

  const loadMore = useCallback(() => {
    // Don't fetch again if we're already loading the next page
    if (isLoadingNext) {
      return;
    }
    loadNext(2);
  }, [isLoadingNext, loadNext]);

  return (
    <div className="shadow sm:rounded-md sm:overflow-hidden">
      <div className="px-4 py-5 bg-white space-y-6 sm:p-6">
        <ul>{rows}</ul>
        <button onClick={loadMore}>Load More</button>
      </div>
    </div>
  );
};

export default PeopleList;
