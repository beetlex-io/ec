using System;
using System.Collections.Generic;
using System.Text;

namespace Peanut
{
    public class SqliteDriver : Peanut.DriverTemplate<
        System.Data.SQLite.SQLiteConnection,
        System.Data.SQLite.SQLiteCommand,
        System.Data.SQLite.SQLiteDataAdapter,
        System.Data.SQLite.SQLiteParameter,
        Peanut.SqlitBuilder>
    {
    }
}
