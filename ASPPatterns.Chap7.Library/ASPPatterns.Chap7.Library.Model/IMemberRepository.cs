using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.Query;

namespace ASPPatterns.Chap7.Library.Model
{
    public interface IMemberRepository
    {
        void Add(Member member);
        void Remove(Member member);
        void Save(Member member);        

        Member FindBy(Guid Id);
        
        IEnumerable<Member> FindAll();
        IEnumerable<Member> FindAll(int index, int count);

        IEnumerable<Member> FindBy(Query query);
        IEnumerable<Member> FindBy(Query query, int index, int count);        
    }
}
