using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FlexMerchant.Core
{
    public class ProductFactory
    {
        static Product[] db1 = new Product[] 
        { 
            new Product { Id = 101, Name = "p101" },
            new Product { Id = 102, Name = "p102" }, 
            new Product { Id = 103, Name = "P103" }, 
            new Product { Id = 104, Name = "p104" },
            new Product { Id = 105, Name = "p105"}, 
            new Product { Id = 106, Name = "p106" }, 
            new Product { Id = 107, Name = "p107" }, 
            new Product { Id = 108, Name = "p108" }, 
            new Product { Id = 109, Name = "p109" },
            new Product { Id = 110, Name = "p110" }, 
            new Product { Id = 111, Name = "p111" }, 
            new Product { Id = 112, Name = "p112"},
            new Product { Id = 113, Name = "p113" }, 
            new Product { Id = 114, Name = "p114" }, 
            new Product { Id = 115, Name = "p115" }, 
            new Product { Id = 116, Name = "p116" } 
        };
        static Product[] db2 = new Product[] 
        { 
            new Product { Id = 201, Name = "p201" },
            new Product { Id = 202, Name = "p202" }, 
            new Product { Id = 203, Name = "p203" }, 
            new Product { Id = 204, Name = "p204" },
            new Product { Id = 205, Name = "p205"}, 
            new Product { Id = 206, Name = "p206" }, 
            new Product { Id = 207, Name = "p207" }, 
            new Product { Id = 208, Name = "p208" }, 
            new Product { Id = 209, Name = "p209" },
            new Product { Id = 200, Name = "p210" }, 
            new Product { Id = 211, Name = "p211" }, 
            new Product { Id = 212, Name = "p212"},
            new Product { Id = 213, Name = "p213" }, 
            new Product { Id = 214, Name = "p214" }, 
            new Product { Id = 215, Name = "p215" }, 
            new Product { Id = 216, Name = "p216" } 
        };
        static Product[] db3 = new Product[] 
        { 
            new Product { Id = 301, Name = "p301" },
            new Product { Id = 302, Name = "p302" }, 
            new Product { Id = 303, Name = "p303" }, 
            new Product { Id = 304, Name = "p304" },
            new Product { Id = 305, Name = "p305"}, 
            new Product { Id = 306, Name = "p306" }, 
            new Product { Id = 307, Name = "p307" }, 
            new Product { Id = 308, Name = "p308" }, 
            new Product { Id = 309, Name = "p309" },
            new Product { Id = 310, Name = "p310" }, 
            new Product { Id = 311, Name = "p311" }, 
            new Product { Id = 312, Name = "p312"},
            new Product { Id = 313, Name = "p313" }, 
            new Product { Id = 314, Name = "p314" }, 
            new Product { Id = 315, Name = "p315" }, 
            new Product { Id = 316, Name = "p316" } 
        };
        static Product[] db4 = new Product[] 
        { 
            new Product { Id = 401, Name = "p401", Template="stereoproductTemplate"  },
            new Product { Id = 402, Name = "p402", Template="stereoproductTemplate"  }, 
            new Product { Id = 403, Name = "p403", Template="stereoproductTemplate"  }, 
            new Product { Id = 404, Name = "p404", Template="stereoproductTemplate"  },
            new Product { Id = 405, Name = "p405", Template="stereoproductTemplate"  }, 
            new Product { Id = 406, Name = "p406", Template="stereoproductTemplate"  }, 
            new Product { Id = 407, Name = "p407", Template="stereoproductTemplate"  }, 
            new Product { Id = 408, Name = "p408", Template="stereoproductTemplate"  }, 
            new Product { Id = 409, Name = "p409", Template="stereoproductTemplate"  },
            new Product { Id = 410, Name = "p410", Template="stereoproductTemplate"  }, 
            new Product { Id = 411, Name = "p411", Template="stereoproductTemplate"  }, 
            new Product { Id = 412, Name = "p412", Template="stereoproductTemplate"  },
            new Product { Id = 413, Name = "p413", Template="stereoproductTemplate"  }, 
            new Product { Id = 414, Name = "p414", Template="stereoproductTemplate"  }, 
            new Product { Id = 415, Name = "p415", Template="stereoproductTemplate"  }, 
            new Product { Id = 416, Name = "p416", Template="stereoproductTemplate"  } 
        };
        static Product[] db5 = new Product[] 
        { 
            new Product { Id = 501, Name = "p501", Template="stereoproductTemplate"  },
            new Product { Id = 502, Name = "p502", Template="stereoproductTemplate"  }, 
            new Product { Id = 503, Name = "p503", Template="stereoproductTemplate"  }, 
            new Product { Id = 504, Name = "p504", Template="stereoproductTemplate"  },
            new Product { Id = 505, Name = "p505", Template="stereoproductTemplate"  }, 
            new Product { Id = 506, Name = "p506", Template="stereoproductTemplate"  }, 
            new Product { Id = 507, Name = "p507", Template="stereoproductTemplate"  }, 
            new Product { Id = 508, Name = "p508", Template="stereoproductTemplate"  }, 
            new Product { Id = 509, Name = "p509", Template="stereoproductTemplate"  },
            new Product { Id = 510, Name = "p510", Template="stereoproductTemplate"  }, 
            new Product { Id = 511, Name = "p511", Template="stereoproductTemplate"  }, 
            new Product { Id = 512, Name = "p512", Template="stereoproductTemplate"  },
            new Product { Id = 513, Name = "p513", Template="stereoproductTemplate"  }, 
            new Product { Id = 514, Name = "p514", Template="stereoproductTemplate"  }, 
            new Product { Id = 515, Name = "p515", Template="stereoproductTemplate"  }, 
            new Product { Id = 516, Name = "p516", Template="stereoproductTemplate"  } 
        };
        static Product[] db6 = new Product[] 
        { 
            new Product { Id = 601, Name = "p601", Template="stereoproductTemplate" },
            new Product { Id = 602, Name = "p602", Template="stereoproductTemplate" }, 
            new Product { Id = 603, Name = "p603", Template="stereoproductTemplate" }, 
            new Product { Id = 604, Name = "p604", Template="stereoproductTemplate"  },
            new Product { Id = 605, Name = "p605", Template="stereoproductTemplate" }, 
            new Product { Id = 606, Name = "p606", Template="stereoproductTemplate"  }, 
            new Product { Id = 607, Name = "p607", Template="stereoproductTemplate"  }, 
            new Product { Id = 608, Name = "p608", Template="stereoproductTemplate"  }, 
            new Product { Id = 609, Name = "p609", Template="stereoproductTemplate"  },
            new Product { Id = 610, Name = "p610", Template="stereoproductTemplate"  }, 
            new Product { Id = 611, Name = "p611", Template="stereoproductTemplate"  }, 
            new Product { Id = 612, Name = "p612", Template="stereoproductTemplate"  },
            new Product { Id = 613, Name = "p613", Template="stereoproductTemplate"  }, 
            new Product { Id = 614, Name = "p614", Template="stereoproductTemplate"  }, 
            new Product { Id = 615, Name = "p615", Template="stereoproductTemplate"  }, 
            new Product { Id = 616, Name = "p616", Template="stereoproductTemplate"  } 
        };
        static ArrayList dblist = new ArrayList { db1, db2, db3, db4, db5, db6 };

        public static List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            list.AddRange(db1);
            list.AddRange(db2);
            list.AddRange(db3);
            list.AddRange(db4);
            list.AddRange(db5);
            list.AddRange(db6);
            return list;
        }

        public static Product Get(int id)
        {
            IEnumerable<Product> result = from c in GetAll() where c.Id == id select  c;
            if (result.Count()>0) 
                return result.First();
            return null;
        }

        public static PagedResult<Product> Get(Category category, int page, int pagesize)
        {
            int minIndex = (page - 1) * pagesize;
            int maxIndex = page * pagesize;
            List<Product> products = new List<Product>();
            Product[] db = (Product[])dblist[category.Id-1];
            
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (i < db.Length)
                {
                    db[i].Category = category;
                    products.Add(db[i]);
                }
                else
                {
                    break;
                }
            }
            return new PagedResult<Product> { List = products, TotalRows = db.Length, PageSize=pagesize };
        }
    }

    public class CategoryFactory
    {        
    }
}
