﻿using HeavensAbove.Content.Tiles;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace HeavensAbove.Structures
{
    // TODO: Add structure tilemap for the structure generation later if needed
    public struct StructureData
    {

        static int tileID = ModContent.TileType<DungeonTile>();
        static int wallID = ModContent.WallType<DungeonWall>();
        static int altID = ModContent.TileType<SunSpiritAltar>();

        public static int[,] testStructure = new int[,]
        {
              {tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID},
   {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
   {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
   {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,tileID,tileID,tileID,tileID,tileID,tileID,tileID,tileID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
   {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
   {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
};

        public static int[,] testStructureFurniture = new int[,]
        {
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,altID,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}
};

        public static int[,] testStructureWalls = new int[,]
        {
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID},
    {wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID,wallID}
    };
    }

    public class Structure
    {
        private int[,] structureData;

        private int[,] wallData;

        private int posX;
        private int posY;

        public Structure(int _x, int _y, int type = 0)
        {
            posX = _x;
            posY = _y;

            switch (type)
            {
                case 0:
                case 1:
                case 2:
                default:
                    structureData = StructureData.testStructure;
                    wallData = StructureData.testStructureWalls;
                    break;
            }
        }

        public void Generate()
        {
            // Generates the strucutre with walls assuming the wall structure and block structure are the same size
            for (int y = 0; y < structureData.GetLength(0); y++)
            {
                //System.Console.WriteLine("Generating row:" + y);
                for (int x = 0; x < structureData.GetLength(1); x++)
                {
                    //System.Console.WriteLine("Generating collumn:" + x);
                    Tile tile = Main.tile[posX + x, posY + y];
                    if (StructureData.testStructure[y, x] != -1)
                    {
                        //System.Console.WriteLine("tile type:" + (ushort)StructureData.testStructure[y, x]);
                        tile.HasTile = true;
                        tile.TileType = (ushort)StructureData.testStructure[y, x];
                    }
                    else
                    {
                        tile.HasTile = false;
                    }
                    if (StructureData.testStructureWalls[y, x] != -1)
                    {
                        tile.WallType = (ushort)StructureData.testStructureWalls[y, x];
                    }
                }
            }

            for (int y = 0; y < structureData.GetLength(0); y++)
            {
                //System.Console.WriteLine("Generating row:" + y);
                for (int x = 0; x < structureData.GetLength(1); x++)
                {
                    if (StructureData.testStructureFurniture[y, x] == ModContent.TileType<SunSpiritAltar>())
                    {
                        WorldGen.Place3x2(posX + x, posY + y, (ushort)ModContent.TileType<SunSpiritAltar>());
                    }
                }
            }
        }
    }
}
