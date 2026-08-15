using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LinqTests.Entities;

namespace LinqTests
{
    /*
     * ============================================================
     *  LINQ TESTS - "COLA" DE OPERAÇÕES DO LINQ
     * ============================================================
     *  Projeto de referência com as principais operações do LINQ
     *  aplicadas sobre uma lista de Product / Category.
     *
     *  Conceitos gerais importantes:
     *
     *  - LINQ trabalha sobre IEnumerable<T> (LINQ to Objects) e
     *    IQueryable<T> (LINQ to Entities / banco de dados).
     *
     *  - EXECUÇÃO ADIADA (deferred execution): a maioria dos
     *    operadores (Where, Select, OrderBy, GroupBy...) NÃO executa
     *    na hora em que a query é escrita. Ela só é executada quando
     *    a coleção é percorrida (foreach, ToList, Count, etc.).
     *
     *  - EXECUÇÃO IMEDIATA: operadores que retornam um valor único
     *    ou uma nova coleção materializada (Count, Sum, Max, First,
     *    ToList, ToArray, ToDictionary...) executam na hora.
     * ============================================================
     */
    class Program
    {
        // Método auxiliar genérico: imprime um cabeçalho e todos os
        // elementos de qualquer coleção que implemente IEnumerable<T>.
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // MASSA DE DADOS
            // ------------------------------------------------------------
            // Obs.: c1, c2 e c3 são as MESMAS referências usadas por todos
            // os produtos. Isso é o que faz o GroupBy(p => p.Category)
            // funcionar corretamente mais abaixo (comparação por referência).
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Category> categories = new List<Category>() { c1, c2, c3 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            /* ============================================================
             * 1) FILTRAGEM - Where
             * ============================================================
             * Where recebe um predicado (Func<T, bool>) e devolve APENAS os
             * elementos em que o predicado é verdadeiro. Não altera a lista
             * original: cria uma nova sequência.
             */
            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900:", r1);

            /* ============================================================
             * 2) FILTRAGEM + PROJEÇÃO SIMPLES - Where + Select
             * ============================================================
             * Select transforma cada elemento em outra coisa (projeção).
             * Aqui, de IEnumerable<Product> passa a ser IEnumerable<string>,
             * porque estamos selecionando somente o Name.
             */
            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS", r2);

            /* ============================================================
             * 3) PROJEÇÃO COM OBJETO ANÔNIMO - Select + new { }
             * ============================================================
             * Quando você precisa de mais de uma propriedade, mas não quer
             * criar uma classe só para isso, usa-se um tipo anônimo.
             * O compilador gera a classe automaticamente (por isso var).
             * Também é possível renomear campos (CategoryName = ...).
             */
            var r3 = products.Where(p => p.Name[0] == 'C')
                             .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);

            /* ============================================================
             * 4) ORDENAÇÃO - OrderBy + ThenBy
             * ============================================================
             * OrderBy define o critério principal (crescente).
             * ThenBy define o critério de desempate.
             * ATENÇÃO: nunca use OrderBy duas vezes seguidas para isso -
             * o segundo OrderBy descarta a ordenação anterior.
             */
            var r4 = products.Where(p => p.Category.Tier == 1)
                             .OrderBy(p => p.Price)
                             .ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            /* ============================================================
             * 5) PAGINAÇÃO - Skip + Take
             * ============================================================
             * Skip(n) pula os n primeiros elementos.
             * Take(n) pega os n elementos seguintes.
             * Combinação clássica para paginação:
             *      .Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina)
             */
            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

            /* ============================================================
             * 6) PRIMEIRO ELEMENTO - FirstOrDefault
             * ============================================================
             * First()          -> lança exceção se a coleção estiver vazia.
             * FirstOrDefault() -> retorna o valor padrão (null para classes,
             *                     0 para int, etc.) quando não há elementos.
             */
            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test1: " + r6);
            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default test2: " + r7);
            Console.WriteLine();

            /* ============================================================
             * 7) ELEMENTO ÚNICO - SingleOrDefault
             * ============================================================
             * Single()          -> exige EXATAMENTE um elemento; lança
             *                      exceção se houver zero ou mais de um.
             * SingleOrDefault() -> aceita zero (retorna default), mas ainda
             *                      lança exceção se houver mais de um.
             * Ideal para buscas por chave primária / Id.
             */
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or default test1: " + r8);
            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("Single or default test2: " + r9);
            Console.WriteLine();

            /* ============================================================
             * 8) AGREGAÇÕES - Max, Min, Sum, Average, Aggregate
             * ============================================================
             * Todos são de execução IMEDIATA (percorrem a coleção na hora).
             * Max/Min/Sum/Average lançam exceção em coleção vazia (exceto
             * Sum, que retorna 0) - daí a utilidade do DefaultIfEmpty.
             */
            var r10 = products.Max(p => p.Price);
            Console.WriteLine("Max price: " + r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price: " + r11);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r12);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r13);

            // DefaultIfEmpty: se a sequência vier vazia, ela passa a conter
            // um único elemento com o valor informado (evita a exceção do Average).
            var r14 = products.Where(p => p.Category.Id == 5)
                              .Select(p => p.Price)
                              .DefaultIfEmpty(0.0)
                              .Average();
            Console.WriteLine("Category 5 Average prices: " + r14);

            // Aggregate: acumulador genérico. Recebe um valor inicial (seed)
            // e uma função (acumulado, próximo) => novo acumulado.
            var r15 = products.Where(p => p.Category.Id == 1)
                              .Select(p => p.Price)
                              .Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Category 1 aggregate sum: " + r15);
            Console.WriteLine();

            /* ============================================================
             * 9) AGRUPAMENTO - GroupBy
             * ============================================================
             * GroupBy devolve IEnumerable<IGrouping<TKey, TElement>>.
             * Cada grupo tem uma Key (a chave do agrupamento) e é, ele
             * mesmo, uma coleção dos elementos daquele grupo.
             */
            var r16 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ":");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            /* ============================================================
             * ============================================================
             *      A PARTIR DAQUI: OPERAÇÕES ADICIONAIS DO LINQ
             * ============================================================
             * ============================================================
             */

            /* ============================================================
             * 10) ORDENAÇÃO DECRESCENTE - OrderByDescending / ThenByDescending
             * ============================================================
             * Mesma lógica do OrderBy/ThenBy, mas do maior para o menor.
             * Dá para misturar: OrderBy(...).ThenByDescending(...).
             */
            var r17 = products.OrderByDescending(p => p.Price).ThenByDescending(p => p.Name);
            Print("ORDER BY PRICE DESC THEN BY NAME DESC:", r17);

            /* ============================================================
             * 11) INVERTER A ORDEM - Reverse
             * ============================================================
             * PEGADINHA CLÁSSICA: List<T> possui um método próprio
             * Reverse() que INVERTE A LISTA ORIGINAL e retorna void.
             * Para usar o Reverse do LINQ (que gera uma nova sequência e
             * não altera a original) chame AsEnumerable() antes, ou
             * aplique sobre o resultado de um Where/Select.
             */
            var r18 = products.AsEnumerable().Reverse();
            Print("REVERSE (ordem inversa da lista original):", r18);

            /* ============================================================
             * 12) CONTAGEM - Count / LongCount
             * ============================================================
             * Count() sem argumento conta todos os elementos.
             * Count(predicado) já filtra e conta em uma única passada.
             * LongCount() é a versão que retorna long (coleções enormes).
             */
            Console.WriteLine("Count (total de produtos): " + products.Count());
            Console.WriteLine("Count com predicado (preço > 700): " + products.Count(p => p.Price > 700.0));
            Console.WriteLine();

            /* ============================================================
             * 13) VERIFICAÇÕES LÓGICAS - Any / All / Contains
             * ============================================================
             * Any()            -> existe pelo menos um elemento?
             * Any(predicado)   -> existe algum que satisfaça a condição?
             * All(predicado)   -> TODOS satisfazem a condição?
             * Contains(item)   -> a coleção contém esse elemento?
             *
             * DICA DE PERFORMANCE: prefira Any() a Count() > 0, pois Any
             * para na primeira ocorrência em vez de percorrer tudo.
             */
            Console.WriteLine("Any (existe produto acima de 1500?): " + products.Any(p => p.Price > 1500.0));
            Console.WriteLine("All (todos custam mais de 50?): " + products.All(p => p.Price > 50.0));
            Console.WriteLine("Contains (a lista contém o objeto products[0]?): " + products.Contains(products[0]));
            Console.WriteLine();

            /* ============================================================
             * 14) ACESSO POR POSIÇÃO E FIM DA COLEÇÃO
             *     Last / LastOrDefault / ElementAt / ElementAtOrDefault
             * ============================================================
             * Last() e ElementAt() lançam exceção quando não encontram;
             * as versões OrDefault retornam o valor padrão.
             */
            Console.WriteLine("Last: " + products.Last());
            Console.WriteLine("LastOrDefault (preço > 5000, não existe): " + products.LastOrDefault(p => p.Price > 5000.0));
            Console.WriteLine("ElementAt(2): " + products.ElementAt(2));
            Console.WriteLine("ElementAtOrDefault(50): " + products.ElementAtOrDefault(50));
            Console.WriteLine();

            /* ============================================================
             * 15) FILTRO CONDICIONAL SEQUENCIAL - TakeWhile / SkipWhile
             * ============================================================
             * Diferente do Where, esses operadores PARAM na primeira vez
             * que a condição falha - eles dependem da ORDEM da coleção.
             * TakeWhile: pega enquanto a condição for verdadeira.
             * SkipWhile: pula enquanto for verdadeira e retorna o resto.
             */
            var ordenadosPorPreco = products.OrderBy(p => p.Price).ToList();
            var r19 = ordenadosPorPreco.TakeWhile(p => p.Price < 700.0);
            Print("TAKE WHILE (preço < 700, na lista ordenada):", r19);

            var r20 = ordenadosPorPreco.SkipWhile(p => p.Price < 700.0);
            Print("SKIP WHILE (preço < 700, na lista ordenada):", r20);

            /* ============================================================
             * 16) FIM DA COLEÇÃO - TakeLast / SkipLast
             * ============================================================
             * TakeLast(n): pega os n últimos elementos.
             * SkipLast(n): descarta os n últimos elementos.
             *
             * ATENÇÃO: só existem no .NET Core 2.0+ / .NET Standard 2.1+.
             * No .NET Framework use Skip com a contagem, como abaixo:
             *      products.TakeLast(3)  ==  products.Skip(products.Count - 3)
             *      products.SkipLast(3)  ==  products.Take(products.Count - 3)
             */
            var r21 = products.Skip(products.Count - 3).Select(p => p.Name);
            Print("TAKE LAST 3 (nomes):", r21);

            var r21b = products.Take(products.Count - 3).Select(p => p.Name);
            Print("SKIP LAST 3 (nomes):", r21b);

            /* ============================================================
             * 17) ELEMENTOS DISTINTOS - Distinct
             * ============================================================
             * Distinct remove duplicatas usando Equals/GetHashCode.
             * Para objetos sem override desses métodos (como Product), a
             * comparação é por REFERÊNCIA - por isso aqui aplicamos sobre
             * valores simples (preços), onde o resultado é útil.
             */
            var r22 = products.Select(p => p.Price).Distinct().OrderBy(price => price);
            Print("DISTINCT (preços únicos):", r22);

            /* ============================================================
             * 18) OPERAÇÕES DE CONJUNTO - Union / Intersect / Except / Concat
             * ============================================================
             * Union     -> união SEM duplicatas.
             * Concat    -> união COM duplicatas (apenas emenda as listas).
             * Intersect -> apenas o que existe nas duas coleções.
             * Except    -> o que existe na primeira e NÃO na segunda.
             */
            var baratos = products.Where(p => p.Price < 800.0);
            var tier1 = products.Where(p => p.Category.Tier == 1);

            Print("UNION (baratos OU tier 1):", baratos.Union(tier1).Select(p => p.Name));
            Print("INTERSECT (baratos E tier 1):", baratos.Intersect(tier1).Select(p => p.Name));
            Print("EXCEPT (baratos que NÃO são tier 1):", baratos.Except(tier1).Select(p => p.Name));
            Print("CONCAT (emenda, mantendo repetidos):", baratos.Concat(tier1).Select(p => p.Name));

            /* ============================================================
             * 19) ACHATAR COLEÇÕES - SelectMany
             * ============================================================
             * Enquanto Select gera uma coleção DE coleções, SelectMany
             * "achata" tudo em uma única sequência. Muito usado quando o
             * objeto possui uma lista dentro dele (ex.: Pedido -> Itens).
             * Aqui, cada nome é quebrado em palavras e todas as palavras
             * de todos os produtos viram uma lista só.
             */
            var r23 = products.SelectMany(p => p.Name.Split(' ')).Distinct();
            Print("SELECT MANY (todas as palavras dos nomes):", r23);

            /* ============================================================
             * 20) PROJEÇÃO COM ÍNDICE - Select com sobrecarga (item, index)
             * ============================================================
             * Existe uma sobrecarga do Select (e do Where) que fornece a
             * posição do elemento na sequência.
             */
            var r24 = products.Select((p, index) => (index + 1) + "º - " + p.Name);
            Print("SELECT COM ÍNDICE:", r24);

            /* ============================================================
             * 21) GROUP BY COM PROJEÇÃO (relatório agregado)
             * ============================================================
             * Padrão mais usado no dia a dia: agrupar e já calcular
             * estatísticas de cada grupo em um objeto anônimo.
             * Equivale ao GROUP BY + funções agregadas do SQL.
             */
            var r25 = products.GroupBy(p => p.Category.Tier)
                              .Select(g => new
                              {
                                  Tier = g.Key,
                                  Quantidade = g.Count(),
                                  Total = g.Sum(p => p.Price),
                                  Media = g.Average(p => p.Price),
                                  MaisCaro = g.Max(p => p.Price)
                              })
                              .OrderBy(x => x.Tier);
            Print("GROUP BY TIER COM AGREGAÇÕES:", r25);

            /* ============================================================
             * 22) JOIN (equivale ao INNER JOIN do SQL)
             * ============================================================
             * Junta duas coleções por uma chave em comum.
             * Assinatura: Join(outraColecao,
             *                  chaveDaPrimeira,
             *                  chaveDaSegunda,
             *                  (a, b) => resultado)
             */
            var r26 = categories.Join(
                            products,
                            cat => cat.Id,                 // chave da coleção externa
                            prod => prod.Category.Id,      // chave da coleção interna
                            (cat, prod) => new { Categoria = cat.Name, Produto = prod.Name, prod.Price });
            Print("JOIN (categoria x produto):", r26);

            /* ============================================================
             * 23) GROUP JOIN (equivale a um LEFT JOIN agrupado)
             * ============================================================
             * Para cada elemento da primeira coleção, devolve o elemento
             * e a COLEÇÃO de correspondências da segunda. Categorias sem
             * produtos aparecem com a lista vazia.
             */
            var r27 = categories.GroupJoin(
                            products,
                            cat => cat.Id,
                            prod => prod.Category.Id,
                            (cat, prods) => new { Categoria = cat.Name, Quantidade = prods.Count() });
            Print("GROUP JOIN (categoria e nº de produtos):", r27);

            /* ============================================================
             * 24) COMBINAR DUAS SEQUÊNCIAS - Zip
             * ============================================================
             * Percorre duas coleções em paralelo, elemento a elemento.
             * O resultado tem o tamanho da MENOR das duas coleções.
             */
            var posicoes = new List<string>() { "Ouro", "Prata", "Bronze" };
            var maisCaros = products.OrderByDescending(p => p.Price).Select(p => p.Name);
            var r28 = posicoes.Zip(maisCaros, (medalha, nome) => medalha + ": " + nome);
            Print("ZIP (ranking dos mais caros):", r28);

            /* ============================================================
             * 25) COMPARAR SEQUÊNCIAS - SequenceEqual
             * ============================================================
             * Retorna true se as duas coleções tiverem os mesmos elementos,
             * na mesma ordem e na mesma quantidade.
             */
            var listaA = products.Take(3).Select(p => p.Name);
            var listaB = products.Take(3).Select(p => p.Name);
            Console.WriteLine("SequenceEqual (3 primeiros nomes x 3 primeiros nomes): "
                              + listaA.SequenceEqual(listaB));
            Console.WriteLine();

            /* ============================================================
             * 26) ADICIONAR ELEMENTOS À SEQUÊNCIA - Append / Prepend
             * ============================================================
             * Criam uma NOVA sequência com o elemento no fim (Append) ou
             * no início (Prepend). A coleção original não é modificada.
             */
            var r29 = products.Select(p => p.Name).Prepend(">>> INÍCIO").Append("<<< FIM");
            Print("PREPEND / APPEND:", r29);

            /* ============================================================
             * 27) FILTRO POR TIPO - OfType / Cast
             * ============================================================
             * OfType<T>() filtra apenas os elementos do tipo T (ignora o
             * resto sem erro). Cast<T>() converte TODOS e lança exceção se
             * algum elemento não for daquele tipo.
             */
            List<object> misturado = new List<object>() { 10, "texto", 2.5, c1, "outro", 42 };
            Print("OF TYPE <string> (só as strings da lista mista):", misturado.OfType<string>());
            Print("OF TYPE <int> (só os inteiros da lista mista):", misturado.OfType<int>());

            /* ============================================================
             * 28) MATERIALIZAÇÃO - ToList / ToArray / ToDictionary / ToLookup
             * ============================================================
             * Forçam a execução IMEDIATA da query e guardam o resultado
             * em memória. Muito importante quando a query será usada mais
             * de uma vez (evita reexecutar o filtro toda vez).
             */
            List<Product> listaMaterializada = products.Where(p => p.Price > 1000.0).ToList();
            Product[] arrayMaterializado = products.Where(p => p.Price > 1000.0).ToArray();
            Console.WriteLine("ToList Count: " + listaMaterializada.Count
                              + " | ToArray Length: " + arrayMaterializado.Length);

            // ToDictionary: chave única obrigatória (lança exceção se repetir).
            Dictionary<int, string> dicionario = products.ToDictionary(p => p.Id, p => p.Name);
            Console.WriteLine("ToDictionary - produto de Id 4: " + dicionario[4]);

            // ToLookup: como um dicionário, mas cada chave aponta para VÁRIOS
            // elementos. É basicamente um GroupBy já materializado.
            ILookup<string, Product> lookup = products.ToLookup(p => p.Category.Name);
            Console.WriteLine("ToLookup - produtos da categoria 'Tools': "
                              + string.Join(", ", lookup["Tools"].Select(p => p.Name)));
            Console.WriteLine();

            /* ============================================================
             * 29) MAIOR / MENOR ELEMENTO PELO VALOR DE UMA PROPRIEDADE
             * ============================================================
             * Diferença importante em relação a Max/Min:
             *   Max(p => p.Price)   -> devolve o VALOR (1800.0)
             *   MaxBy(p => p.Price) -> devolve o OBJETO inteiro (o Product)
             *
             * MaxBy/MinBy só existem no .NET 6+. No .NET Framework a forma
             * equivalente é ordenar e pegar o primeiro:
             *   products.MaxBy(p => p.Price) == products.OrderByDescending(p => p.Price).First()
             *   products.MinBy(p => p.Price) == products.OrderBy(p => p.Price).First()
             */
            Console.WriteLine("Produto mais caro: " + products.OrderByDescending(p => p.Price).First());
            Console.WriteLine("Produto mais barato: " + products.OrderBy(p => p.Price).First());
            Console.WriteLine();

            /* ============================================================
             * 30) DISTINCT POR PROPRIEDADE
             * ============================================================
             * DistinctBy / UnionBy / ExceptBy / IntersectBy aceitam um
             * seletor de chave, eliminando duplicatas por uma PROPRIEDADE
             * em vez do objeto inteiro. Só existem no .NET 6+.
             *
             * Equivalente clássico (funciona em qualquer versão): agrupar
             * pela propriedade e pegar o primeiro de cada grupo.
             *   products.DistinctBy(p => p.Price)
             *        == products.GroupBy(p => p.Price).Select(g => g.First())
             */
            var r30 = products.GroupBy(p => p.Price)
                              .Select(g => g.First())
                              .OrderBy(p => p.Price);
            Print("DISTINCT BY PRICE (um produto por faixa de preço):", r30);

            /* ============================================================
             * 31) DIVIDIR EM BLOCOS (lotes)
             * ============================================================
             * Quebra a sequência em blocos (arrays) de tamanho fixo. O
             * último bloco pode vir menor. Útil para processar em lotes.
             *
             * Chunk(n) só existe no .NET 6+. Equivalente em qualquer versão:
             * usar o índice de cada elemento dividido pelo tamanho do bloco
             * como chave de agrupamento (divisão inteira).
             */
            var blocos = products.Select((p, index) => new { p, index })
                                 .GroupBy(x => x.index / 4)
                                 .Select(g => g.Select(x => x.p).ToArray());

            Console.WriteLine("CHUNK (blocos de 4 produtos):");
            foreach (Product[] bloco in blocos)
            {
                Console.WriteLine("[" + string.Join(" | ", bloco.Select(p => p.Name)) + "]");
            }
            Console.WriteLine();

            /* ============================================================
             * 32) GERADORES - Range / Repeat / Empty
             * ============================================================
             * Não partem de uma coleção existente: criam sequências.
             * Range(início, quantidade), Repeat(valor, quantidade),
             * Empty<T>() (sequência vazia, útil como valor padrão).
             */
            Print("RANGE (1 a 5):", Enumerable.Range(1, 5));
            Print("REPEAT ('LINQ' x3):", Enumerable.Repeat("LINQ", 3));

            /* ============================================================
             * 33) SINTAXE DE CONSULTA (query syntax)
             * ============================================================
             * Alternativa à sintaxe de métodos (lambda). O compilador
             * traduz uma para a outra - o resultado é idêntico.
             * Nem todos os operadores existem na sintaxe de consulta
             * (Count, Any, Skip/Take etc. exigem sintaxe de método).
             */
            var r31 = from p in products
                      where p.Category.Tier == 1 && p.Price > 900.0
                      orderby p.Price descending
                      select new { p.Name, p.Price };
            Print("QUERY SYNTAX (tier 1, preço > 900, decrescente):", r31);

            /* ============================================================
             * 34) EXECUÇÃO ADIADA NA PRÁTICA (deferred execution)
             * ============================================================
             * A query abaixo é definida ANTES de o novo produto ser
             * inserido, mas como só é executada no momento do foreach,
             * o item novo APARECE no resultado. Se tivesse sido usado
             * .ToList() na definição, o resultado seria "congelado".
             */
            List<Product> demo = new List<Product>() {
                new Product() { Id = 100, Name = "Fone", Price = 200.0, Category = c3 }
            };

            var queryAdiada = demo.Where(p => p.Price > 100.0).Select(p => p.Name);
            var queryMaterializada = demo.Where(p => p.Price > 100.0).Select(p => p.Name).ToList();

            demo.Add(new Product() { Id = 101, Name = "Mouse", Price = 150.0, Category = c3 });

            Print("EXECUÇÃO ADIADA (enxerga o item adicionado depois):", queryAdiada);
            Print("EXECUÇÃO IMEDIATA com ToList (resultado congelado):", queryMaterializada);

            /* ============================================================
             * RESUMO RÁPIDO - "COLA"
             * ============================================================
             * FILTRAR .......... Where, OfType, Cast, DistinctBy
             * PROJETAR ......... Select, SelectMany, Select((p, i) => ...)
             * ORDENAR .......... OrderBy, OrderByDescending, ThenBy,
             *                    ThenByDescending, Reverse
             * PARTICIONAR ...... Skip, Take, SkipWhile, TakeWhile,
             *                    SkipLast, TakeLast, Chunk
             * AGRUPAR/JUNTAR ... GroupBy, Join, GroupJoin, Zip, ToLookup
             * CONJUNTOS ........ Distinct, Union, Intersect, Except, Concat
             * ELEMENTOS ........ First, FirstOrDefault, Last, LastOrDefault,
             *                    Single, SingleOrDefault, ElementAt,
             *                    ElementAtOrDefault, DefaultIfEmpty
             * AGREGAR .......... Count, LongCount, Sum, Min, Max, Average,
             *                    Aggregate, MinBy, MaxBy
             * QUANTIFICAR ...... Any, All, Contains, SequenceEqual
             * CONVERTER ........ ToList, ToArray, ToDictionary, ToLookup,
             *                    AsEnumerable
             * GERAR ............ Range, Repeat, Empty, Append, Prepend
             *
             * SÓ NO .NET 6+ ..... MaxBy, MinBy, Chunk, DistinctBy, UnionBy,
             *                     ExceptBy, IntersectBy
             * SÓ NO .NET CORE ... TakeLast, SkipLast
             * ============================================================
             */
        }
    }
}