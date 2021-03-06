﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Knapcode.KitchenSink.Azure
{
    public class DelegatingCloudTable : ICloudTable
    {
        private readonly CloudTable _table;

        public DelegatingCloudTable(CloudTable table)
        {
            _table = table;
        }

        public Task<TableResult> ExecuteAsync(TableOperation operation, CancellationToken cancellationToken)
        {
            return _table.ExecuteAsync(operation, cancellationToken);
        }

        public Task<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, EntityResolver<TResult> resolver, TableContinuationToken token, CancellationToken cancellationToken)
        {
            return _table.ExecuteQuerySegmentedAsync(query, resolver, token, cancellationToken);
        }

        public Task<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync<TElement>(TableQuery<TElement> query, TableContinuationToken token, CancellationToken cancellationToken) where TElement : ITableEntity, new()
        {
            return _table.ExecuteQuerySegmentedAsync(query, token, cancellationToken);
        }

        public Task CreateAsync(CancellationToken cancellationToken)
        {
            return _table.CreateAsync(cancellationToken);
        }

        public Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken)
        {
            return _table.CreateIfNotExistsAsync(cancellationToken);
        }

        public Task DeleteAsync(CancellationToken cancellationToken)
        {
            return _table.DeleteAsync(cancellationToken);
        }

        public Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken)
        {
            return _table.DeleteIfExistsAsync(cancellationToken);
        }

        public Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return _table.ExistsAsync(cancellationToken);
        }

        public Task<IList<TableResult>> ExecuteBatchAsync(TableBatchOperation batch, CancellationToken cancellationToken)
        {
            return _table.ExecuteBatchAsync(batch, cancellationToken);
        }
    }
}