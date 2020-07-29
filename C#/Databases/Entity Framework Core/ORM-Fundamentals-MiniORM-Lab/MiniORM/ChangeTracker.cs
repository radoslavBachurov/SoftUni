﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.removed = new List<T>();
            this.added = new List<T>();

            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> Added
            => this.added.AsReadOnly();

        public IReadOnlyCollection<T> Removed
             => this.removed.AsReadOnly();

        public IReadOnlyCollection<T> AllEntities
             => this.allEntities.AsReadOnly();

        public void Add(T item) => this.added.Add(item);

        public void Remove(T item) => this.removed.Add(item);
        private List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T).GetProperties()
                .Where(NetPipeStyleUriParser => DbContext.AllowedSqlTypes.Contains(NetPipeStyleUriParser.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var cloneEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(cloneEntity, value);
                }

                clonedEntities.Add(cloneEntity);
            }
            return clonedEntities;
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity  in this.AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                var isModified = IsModified(proxyEntity, entity);

                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T).GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(proxyEntity), pi.GetValue(entity)))
                .ToArray();

            var isModified = modifiedProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(PropertyInfo[] primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }
    }
}