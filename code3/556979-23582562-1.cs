    public static IDigraph DijkstrasAlgorithm(IDigraph g, int s)
            {
                //Collect number of vertices
                int num1 = g.NumberOfVertices;
    
                //create an array for vertices
                Entry[] entryArray1 = new Graphos.Algorithms.Entry[num1];
    
                //for each vertice create new instance for entry of edges
                for (int num2 = 0; num2 < num1; num2++)
                {
                    entryArray1[num2] = new Graphos.Algorithms.Entry(false, 0x7fffffff, 0x7fffffff);
                }
                //set vertice origin with distance 0.
                entryArray1[s].distance = 0;
    
                //create a list for edges
                PriorityQueue queue1 = new BinaryHeap(g.NumberOfEdges);
    
                //create initial nodes in edges list
                queue1.Enqueue(new Association(0, g.GetVertex(s)));
    
                //while list is not empty
                while (!queue1.IsEmpty)
                {
                    //creates an association
                    Association association1 = (Association)queue1.DequeueMin();
    
                    //attributes the vertice
                    IVertex vertex1 = (IVertex)association1.Value;
    
                    //if connection is known
                    if (!entryArray1[vertex1.Number].known)
                    {
                        //checks as known
                        entryArray1[vertex1.Number].known = true;
                        //foreach edge founded
                        foreach (Edge edge1 in vertex1.EmanatingEdges)
                        {
                            //creates the vertex that is being used
                            IVertex vertex2 = edge1.MateOf(vertex1);
    
                            //catches the weight since vertice in link
                            int num3 = entryArray1[vertex1.Number].distance + ((int)edge1.Weight);
    
                            //se o peso da ponte for menor que o peso maximo
                            if (entryArray1[vertex2.Number].distance > num3)
                            {
                                //Peso maximo é atualizado para o peso da ponte
                               entryArray1[vertex2.Number].distance = num3;
    
                                //Define o vértice vizinho 
                                entryArray1[vertex2.Number].predecessor = vertex1.Number;
                                
                               //adiciona o vértice com seu vizinho e o peso entre eles na lista
                                queue1.Enqueue(new Association(num3, vertex2));
                            }
                        }
                    }
                }
                //Á este ponto, todas as associações foram feitas
    
                //Cria o objeto grafo como uma lista baseado no numero de vertices
                IDigraph digraph1 = new DigraphAsLists(num1);
    
                //Para cada vértice
                for (int num4 = 0; num4 < num1; num4++)
                {
                    //adiciona o vertice da lista no grafo
                    digraph1.AddVertex(num4, entryArray1[num4].distance);
                }
    
                //para cada vertice
                for (int num5 = 0; num5 < num1; num5++)
                {
                    //Se não for o ponto de origem
                    if (num5 != s)
                    {
                        //adiciona a aresta(origem,destino baseado no vizinho)
                        digraph1.AddEdge(num5, entryArray1[num5].predecessor);
                    }
                }
                //retorna o grafo
                return digraph1;
            }
