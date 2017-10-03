/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ████████▄
      █   ███   ▀███
      █   ███    ███  █    ▄█████  ▄██████  ██████   █    █     ▄█████    █████    ▄█████    █████
      █   ███    ███ ██    ██  ▀  ██    ██ ██    ██ ██    ██   ██   █    ██  ██   ██   █    ██  ██
      █   ███    ███ ██▌   ██     ██    ▀  ██    ██ ██    ██  ▄██▄▄     ▄██▄▄█▀  ▄██▄▄     ▄██▄▄█▀
      █   ███    ███ ██  ▀███████ ██    ▄  ██    ██ ██    ██ ▀▀██▀▀    ▀███████ ▀▀██▀▀    ▀███████
      █   ███   ▄███ ██     ▄  ██ ██    ██ ██    ██  █▄  ▄█    ██   █    ██  ██   ██   █    ██  ██
      █   ████████▀  █    ▄████▀  ██████▀   ██████    ▀██▀     ███████   ██  ██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Recursively traverses the properties of the specified object and any subordinate objects and returns a list of object instances whose
      █  Type is assignable from the specified Type.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.SDK.Common.Discovery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///     Recursively traverses the properties of the specified object and any subordinate objects and returns a list of object
    ///     instances whose <see cref="Type"/> is assignable from the specified <see cref="Type"/>.
    /// </summary>
    /// <remarks>
    ///     <para>Only properties and classes marked with the <see cref="DiscoverableAttribute"/> attribute are traversed.</para>
    ///     <para>
    ///         In order to be discovered, a property must be of a <see cref="Type"/> assignable from the specified
    ///         <see cref="Type"/>, it must be marked with the <see cref="DiscoverableAttribute"/> attribute, the containing class
    ///         must be marked with the <see cref="DiscoverableAttribute"/> attribute, each class within the class hierarchy
    ///         between the specified object and the discoverable object must be marked with the
    ///         <see cref="DiscoverableAttribute"/>, and each property definition used to establish the class hierarchy must be
    ///         marked with the <see cref="DiscoverableAttribute"/>.
    ///     </para>
    ///     <para>
    ///         In layman's terms, the <see cref="Discover{T}(object)"/> method uses the <see cref="DiscoverableAttribute"/>
    ///         attribute as a "trail of breadcrumbs" to each discoverable object.
    ///     </para>
    /// </remarks>
    public static class Discoverer
    {
        #region Public Methods

        /// <summary>
        ///     Recursively traverses the properties of the specified object and any subordinate objects and returns a list of
        ///     object instances whose <see cref="Type"/> is assignable from the specified <see cref="Type"/>.
        /// </summary>
        /// <typeparam name="T">The Type from which discovered objects must be assignable from.</typeparam>
        /// <param name="instance">The object instance to traverse.</param>
        /// <returns>The list of discovered object instances.</returns>
        public static IList<T> Discover<T>(object instance)
        {
            // if the specified object instance isn't discoverable, return an empty list.
            if (!instance.GetType().HasCustomAttribute<DiscoverableAttribute>())
            {
                return new List<T>();
            }

            return Discover<T>(instance, new List<T>());
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Recursively traverses the properties of the specified object instance and searches for properties matching the
        ///     specified <see cref="Type"/>, adding them to the specified instance list and returning it.
        /// </summary>
        /// <typeparam name="T">The Type from which discovered objects must be assignable from.</typeparam>
        /// <param name="instance">The object instance to traverse.</param>
        /// <param name="instances">The list of discovered object instances matching the specified Type.</param>
        /// <returns>The list of discovered object instances.</returns>
        private static IList<T> Discover<T>(object instance, IList<T> instances)
        {
            // check to see if the instance is of type T and add it to the list if so continue to traverse the object's properties
            // in case it is a composite.
            if (typeof(T).IsAssignableFrom(instance.GetType()))
            {
                instances.Add((T)instance);
            }

            foreach (PropertyInfo property in GetDiscoverableProperties(instance.GetType()))
            {
                object value = property.GetValue(instance);

                if (value != null)
                {
                    // watch out for self referencing properties to avoid stack overflows
                    if (!object.ReferenceEquals(value, instance))
                    {
                        // if the value of the retrieved property is assignable from IEnumerable, it is a collection traverse each
                        // member of the collection before moving to the next property.
                        if (typeof(IEnumerable).IsAssignableFrom(value.GetType()))
                        {
                            foreach (object item in (IEnumerable)value)
                            {
                                if (!object.ReferenceEquals(item, instance))
                                {
                                    instances = Discover<T>(item, instances);
                                }
                            }
                        }
                        else
                        {
                            instances = Discover<T>(value, instances);
                        }
                    }
                }
            }

            return instances;
        }

        /// <summary>
        ///     Returns a <see cref="IList{T}"/> containing <see cref="PropertyInfo"/> objects corresponding to the public,
        ///     private, instance and static properties of the specified <see cref="Type"/> which are marked with the
        ///     <see cref="DiscoverableAttribute"/> attribute.
        /// </summary>
        /// <param name="type">The Type for which the properties are to be retrieved.</param>
        /// <returns>A list containing PropertyInfo objects corresponding to the properties of the specified <see cref="Type"/>.</returns>
        private static IList<PropertyInfo> GetDiscoverableProperties(Type type)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
            return type.GetProperties(flags).Where(p => p.HasCustomAttribute<DiscoverableAttribute>()).ToList();
        }

        #endregion Private Methods
    }
}