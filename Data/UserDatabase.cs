using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using username_Keeper.Models;

namespace username_Keeper.Data
{
    public class UserDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Item).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Item)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return Database.Table<Item>().ToListAsync();
        }

        /*public Task<List<Item>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Item>("SELECT * FROM [Item]");
        }*/

       /* public Task<Item> GetItemAsync(int id)
        {
            return Database.Table<Item>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }*/

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

       /* public Task<int> DeleteItemAsync(Item item)
        {
            return Database.DeleteAsync(item);
        }*/
    }
}