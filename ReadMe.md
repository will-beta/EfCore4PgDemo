Entities����
=====================================================================

����
--------------------

* ����ʵ���
* ֻ�ż򵥵�POCO��



����
--------------------

* NETStandard.Library







Dal����
=====================================================================

����
--------------------

* �������ӳ����
* ����ͨ�õ�DbContext
* DbContext�а������־û�����ʵ�弯



����
--------------------

* Microsoft.EntityFrameworkCore
* NETStandard.Library






Dal.Pg����
=====================================================================

����
--------------------

* ��������ʵ�ֲ�
* ��չDbContext
* DbContext��Ϊ��Ч�־û���Ҫ����Ӧ����������ӳ�乤����DB<-->Code



����
--------------------

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Relational
* NETStandard.Library



��Ҫʵ�� db <--> code model ���Զ����ɣ������Ҫ��װ�������߰�����ǰ�汾�����ڼ��������⣩
---------------------------------------------------------------

Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package Microsoft.EntityFrameworkCore.Tools -Pre
Install-Package Microsoft.EntityFrameworkCore.Tools.DotNet -Pre
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL.Design






Bll����
=====================================================================

����
---------------------------------------------------------------

* ҵ���
* ���������Ļ������������־��������������Ӳ㣨Dal.Pg����ֱ��ʹ�ü��ɣ�����������������ͨ��������ע��



����
--------------------

* Dal�㣺��������Dal.Pg��
* Entities��
* NETStandard.Library
* System.Linq.Parallel���Ա�֧�ֲ���LINQ






App����
=====================================================================

����
---------------------------------------------------------------

* ������
* ��������ע��
* ����ҵ��ִ�У���������ҵ�����



����
--------------------

* �������в�
* ҵ������������
* Npgsql.EntityFrameworkCore.PostgreSQL
* Microsoft.Extensions.Configuration.Json
* Microsoft.Extensions.Logging.Console
* Microsoft.Extensions.Logging.Debug







�ο�
=====================================================================

* [ef core for pg�Ĵ�Ӫ](https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL)
* [EntityTypeConfiguration���Զ���ʵ��](http://cgzl.me/2016/10/15/%E4%B8%BA-entity-framework-core-%E6%B7%BB%E5%8A%A0-entitytypeconfiguration/)
* [ASP.NET Core�е�����ע�루4��: ���캯����ѡ��������������ڹ���](http://www.cnblogs.com/artech/p/asp-net-core-di-life-time.html)
* [.Net Core Linux centos7�С�IOCģ��](http://www.cnblogs.com/calvinK/p/5621262.html)
* [How do I configure a .NET Core 1.0.0 Console Application for Dependency Injection, Logging and Configuration?](http://stackoverflow.com/questions/38706959/net-core-console-applicatin-configuration-xml)
* [Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
* [Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration#options-config-objects)
* [Make sure that scoping with AddDbContext is a good experience #1112](https://github.com/aspnet/EntityFramework/issues/1112)
