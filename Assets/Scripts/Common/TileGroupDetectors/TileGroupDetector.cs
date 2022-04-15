using System.Collections.Generic;
using Common.Extensions;
using Common.Interfaces;
using Match3.Core.Interfaces;
using Match3.Core.Models;

namespace Common.TileGroupDetectors
{
    public class TileGroupDetector : ISolvedSequencesConsumer<IUnityGridSlot>
    {
        private readonly ITileDetector[] _tileDetectors;

        public TileGroupDetector(IUnityGameBoardRenderer gameBoardRenderer)
        {
            _tileDetectors = new ITileDetector[]
            {
                new StoneTileDetector(gameBoardRenderer),
                new IceTileDetector(gameBoardRenderer)
            };
        }

        public void OnSequencesSolved(IEnumerable<ItemSequence<IUnityGridSlot>> sequences)
        {
            foreach (var solvedGridSlot in sequences.GetUniqueGridSlots())
            {
                foreach (var tileDetector in _tileDetectors)
                {
                    tileDetector.CheckGridSlot(solvedGridSlot);
                }
            }
        }
    }
}