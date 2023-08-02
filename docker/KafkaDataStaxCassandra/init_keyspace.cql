CREATE KEYSPACE IF NOT EXISTS oscar_keyspace_name
WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };
CREATE KEYSPACE IF NOT EXISTS oscar_keyspace_name
WITH REPLICATION = { 'class' : 'SimpleStrategy', 'replication_factor' : 1 };

USE oscar_keyspace_name;

CREATE TABLE IF NOT EXISTS message_stats (
  date date PRIMARY KEY,
  message_count int
);
