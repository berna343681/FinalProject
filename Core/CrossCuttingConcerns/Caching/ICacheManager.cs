using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Caching;


namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration); // cache birşey ekleyebilmek  
        T Get<T>(string key); // generic version // cache den bir data getirmek 
        object Get(string key);  // generic olmayan versiyonu 
        bool IsAdd(string key); // cache de var mi?
        void Remove(string key); // cache den uçurma 
        void RemoveByPattern(string pattern); // isminde catory olanları uçur 
    }
}
