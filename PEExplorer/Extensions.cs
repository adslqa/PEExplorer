﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEExplorer {
    static class Extensions {
        public static IEnumerable<T> TakeWhileIncluding<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
            var enumerator = collection.GetEnumerator();
            while(enumerator.MoveNext()) {
                yield return enumerator.Current;
                if(!predicate(enumerator.Current))
                    break;
            }
        }

		public static IEnumerable<T> TakeWhileIncluding<T>(this IEnumerable<T> collection, Func<T, int, bool> predicate) {
			var enumerator = collection.GetEnumerator();
			int i = 0;
			while (enumerator.MoveNext()) {
				yield return enumerator.Current;
				if (!predicate(enumerator.Current, i))
					break;
				++i;
			}
		}
	}
}
