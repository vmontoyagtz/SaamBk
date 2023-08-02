SECRET_KEY = '3TfeFNVIGJf4BHJSHh95f424ouU5ENKlVpv8hqCy/V0MUvK5VMlD31V3'

CASSANDRA_DATABASE_URI = 'cassandra://cassandra:9042/oscar_keyspace_name?protocol_version=4'

SQLALCHEMY_DATABASE_MAP = {
    'cassandra': CASSANDRA_DATABASE_URI
}
