module.exports = {
  // ...
  // Configuration options accepted by the `relay-compiler` command-line tool and `babel-plugin-relay`.
  src: '../../.',
  include: [
    './packages/app/src/**',
    './packages/lib/src/**',
    './packages/ui/src/**',
  ],
  schema: '../../schema/schema.graphql',
  language: 'typescript',
};
