module.exports = {
  // ...
  // Configuration options accepted by the `relay-compiler` command-line tool and `babel-plugin-relay`.
  src: '../../.',
  include: [
    './packages/admin/src/**',
    './packages/lib/src/**',
    './packages/ui/src/**',
    './packages/recruit/src/**',
    './packages/candidate-accounts/src/**',
  ],
  schema: '../../schema/schema.graphql',
  language: 'typescript',
};
