﻿using Labyrinth.Data;
using Labyrinth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Data
{
    class LoadLevelFromString : IDataCommunication
    {
        public ALevel loadLevel(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            try
            {
                String[] lines = path.Split('\n');
                Dictionary<Coordinate, Field> level = new Dictionary<Coordinate, Field>();
                for (int i = 0; i < lines.Length; i++)
                {
                    String[] fields = lines[i].Split();
                    if (fields.Length != lines.Length)
                    {
                        throw new DataException("Error during loading level");
                    }
                    for (int j = 0; j < fields.Length; j++)
                    {
                        switch (fields[j])
                        {
                            case "W":
                                level.Add(new Coordinate(i, j), new Field(i, j, FieldType.WALL));
                                break;
                            case "R":
                                level.Add(new Coordinate(i, j), new Field(i, j, FieldType.ROAD));
                                break;
                            default:
                                throw new DataException("Error during loading level");
                        }

                    }
                }

                return new Level(lines.Length, level);
                // bezárul a fájl
            }
            catch // ha bármi hiba történt
            {
                throw new DataException("Error during loading level");
            }
        }

    }
}
