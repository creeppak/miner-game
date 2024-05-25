using System;
using System.Collections.Generic;
using UnityEngine;

public class BlocksMap : SingletonBehaviour<BlocksMap>
{
    [Serializable]
    public class PosAndBlock
    {
        public Vector2Int pos;
        public Block block;
    }
    
    public const float blockSize = 3f;
    
    public List<PosAndBlock> registeredBlocks;

    private Dictionary<Vector2Int, Block> map = new();
    
    public void Register(Block block)
    {
        map.Add(ToBlockPosition(block.transform.position), block);
        registeredBlocks.Add(new PosAndBlock { pos = ToBlockPosition(block.transform.position), block = block });
    }
    
    public void Unregister(Block block)
    {
        map.Remove(ToBlockPosition(block.transform.position));
        registeredBlocks.RemoveAll(posAndBlock => posAndBlock.pos == ToBlockPosition(block.transform.position));
    }

    public Vector2Int ToBlockPosition(Vector3 worldPos3d)
    {
        var worldPos = new Vector2(worldPos3d.x, worldPos3d.z);
        var blockPos = worldPos / blockSize;
        return new Vector2Int(Mathf.FloorToInt(blockPos.x), Mathf.FloorToInt(blockPos.y));
    }

    public Vector3 ToWorldPosition(Vector2Int blockPos)
    {
        return new Vector3(blockPos.x * blockSize, 0f, blockPos.y * blockSize);
    }
    
    public Block GetBlock(Vector2Int position)
    {
        return map.GetValueOrDefault(position);
    }
}