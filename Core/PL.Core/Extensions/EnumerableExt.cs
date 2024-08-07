﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PL.Core.Extensions
{
	public static class EnumerableExt
	{
		public static T PickRandom<T>(this IEnumerable<T> source)
		{
			return source.PickRandom(1).Single();
		}

		public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
		{
			return source.Shuffle().Take(count);
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.OrderBy(x => Guid.NewGuid());
		}

		public static IEnumerable<T> ShowValues<T>(this IEnumerable<T> source)
		{
			foreach (var elem in source)
			{
				yield return elem;
			}
		}
	}
}
