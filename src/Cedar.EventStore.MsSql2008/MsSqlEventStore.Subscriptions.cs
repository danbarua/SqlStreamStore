﻿namespace Cedar.EventStore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Cedar.EventStore.Subscriptions;

    public sealed partial class MsSqlEventStore
    {
        public async Task<IStreamSubscription> SubscribeToStream(
            string streamId,
            int startPosition,
            StreamEventReceived streamEventReceived,
            SubscriptionDropped subscriptionDropped,
            string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var watcher = await _lazySqlEventsWatcher.Value;

            return watcher.SubscribeToStream(streamId, streamEventReceived, subscriptionDropped);
        }

        public Task<IAllStreamSubscription> SubscribeToAll(
            string fromCheckpoint,
            StreamEventReceived streamEventReceived,
            SubscriptionDropped subscriptionDropped = null,
            string name = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}