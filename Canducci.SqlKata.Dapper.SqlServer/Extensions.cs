﻿using SqlKata.Compilers;
using System.Data;

namespace Canducci.SqlKata.Dapper.SqlServer
{
    public static class Extensions
    {
        public static QueryBuilderDapper Build(this IDbConnection connection)
            => new QueryBuilderDapper(connection, new SqlServerCompiler());

        public static QueryBuilderDapper Build(this IDbConnection connection, string table)
            => new QueryBuilderDapper(connection, new SqlServerCompiler(), table);
    }
}