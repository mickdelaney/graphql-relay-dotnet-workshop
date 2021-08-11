import { useMutation } from "react-relay";
import { FunctionComponent } from "react";
import { useForm } from "react-hook-form";
import graphql from "babel-plugin-relay/macro";
import { CreatePerson_AddPersonMutation } from "./__generated__/CreatePerson_AddPersonMutation.graphql";

export interface CreatePersonProps {
  peopleConnectionId: string;
}

/*

import { ConnectionHandler, useMutation } from "react-relay";
import { RecordSourceSelectorProxy } from "relay-runtime";

export const updater = (store: RecordSourceSelectorProxy) => {
  const connectionRecord = ConnectionHandler.getConnection(
    store.getRoot(),
    "PeopleList_people"
  );
  if (!connectionRecord) {
    return;
  }

  const payload = store.getRootField("addPerson");
  if (!payload) {
    return;
  }
  const serverEdge = payload.getLinkedRecord("person");
  if (!serverEdge) {
    return;
  }
  const newEdge = ConnectionHandler.buildConnectionEdge(
    store,
    connectionRecord,
    serverEdge
  );

  if (!connectionRecord || !newEdge) {
    return;
  }
  ConnectionHandler.insertEdgeBefore(connectionRecord, newEdge);
};
*/

export const CreatePerson: FunctionComponent<CreatePersonProps> = ({ peopleConnectionId }) => {
  const [
    createPerson,
    isInFlight,
  ] = useMutation<CreatePerson_AddPersonMutation>(graphql`
    mutation CreatePerson_AddPersonMutation(
      $input: AddPersonInput!,
      $connections: [ID!]!
    ) {
      addPerson(input: $input) {
        person @appendEdge(connections: $connections) {
          cursor
          node {
            id
            name
            webSite
          }
        }
      }
    }
  `);

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = (data: any) => {
    return createPerson({
      variables: {
        connections: [peopleConnectionId],
        input: {
          clientMutationId: data.name,
          name: data.name,
          webSite: data.webSite,
        },
      },
      //updater: updater,
      onCompleted(data) {
        console.log(data);
      },
    });
  };

  if (isInFlight) {
    return <h1>Saving...</h1>;
  }

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="shadow sm:rounded-md sm:overflow-hidden">
        <div className="px-4 py-5 bg-white space-y-6 sm:p-6">
          <div className="grid grid-cols-3 gap-6">
            <div className="col-span-3 sm:col-span-2">
              <label
                htmlFor="company_website"
                className="block text-sm font-medium text-gray-700"
              >
                Name
              </label>
              <div className="mt-1 flex rounded-md shadow-sm">
                <input
                  type="text"
                  className="focus:ring-indigo-500 focus:border-indigo-500 flex-1 block w-full rounded-none rounded-r-md sm:text-sm border-gray-300"
                  {...register("name", { required: true })}
                />
                {errors.nameRequired && <span>Website is required</span>}
              </div>
            </div>
          </div>
          <div className="grid grid-cols-3 gap-6">
            <div className="col-span-3 sm:col-span-2">
              <label
                htmlFor="company_website"
                className="block text-sm font-medium text-gray-700"
              >
                Website
              </label>
              <div className="mt-1 flex rounded-md shadow-sm">
                <input
                  type="text"
                  className="focus:ring-indigo-500 focus:border-indigo-500 flex-1 block w-full rounded-none rounded-r-md sm:text-sm border-gray-300"
                  {...register("webSite", { required: true })}
                />

                {errors.webSiteRequired && <span>Website is required</span>}
              </div>
            </div>
          </div>

          <div className="px-4 py-3 bg-gray-50 text-right sm:px-6">
            <button
              type="submit"
              className="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
            >
              Save
            </button>
          </div>
        </div>
      </div>
    </form>
  );
};
