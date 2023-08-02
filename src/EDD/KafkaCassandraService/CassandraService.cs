using Cassandra;
using ISession = Cassandra.ISession;

namespace KafkaCassandraService
{
    public class CassandraService
    {
        private readonly ISession _session;

        public CassandraService(ISession session)
        {
            _session = session;
        }

        public async Task InsertDataAsync(string keyspace, string table, Guid id, string data)
        {
            var query = $"INSERT INTO {keyspace}.{table} (id, data) VALUES (?, ?)";
            var preparedStatement = _session.Prepare(query);
            var boundStatement = preparedStatement.Bind(id, data);
            await _session.ExecuteAsync(boundStatement).ConfigureAwait(false);
        }

        public async Task<RowSet> GetDataByIdAsync(string keyspace, string table, Guid id)
        {
            var query = $"SELECT * FROM {keyspace}.{table} WHERE id = ?";
            var preparedStatement = _session.Prepare(query);
            var boundStatement = preparedStatement.Bind(id);
            return await _session.ExecuteAsync(boundStatement).ConfigureAwait(false);
        }
    }

}
