using System.Collections.Generic;
using System.Text;
using Common.Interfaces;
using Match3.Core.Interfaces;
using Match3.Core.Models;
using UnityEngine;

namespace Common
{
    public class GameScoreBoard : ISolvedSequencesConsumer<IUnityGridSlot>
    {
        public void OnSequencesSolved(IEnumerable<ItemSequence<IUnityGridSlot>> sequences)
        {
            foreach (var sequence in sequences)
            {
                RegisterSequenceScore(sequence);
            }
        }

        private void RegisterSequenceScore(ItemSequence<IUnityGridSlot> sequence)
        {
            Debug.Log(GetSequenceDescription(sequence));
        }

        private string GetSequenceDescription(ItemSequence<IUnityGridSlot> sequence)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("ContentId <color=yellow>");
            stringBuilder.Append(sequence.SolvedGridSlots[0].Item.ContentId);
            stringBuilder.Append("</color> | <color=yellow>");
            stringBuilder.Append(sequence.SequenceDetectorType.Name);
            stringBuilder.Append("</color> sequence of <color=yellow>");
            stringBuilder.Append(sequence.SolvedGridSlots.Count);
            stringBuilder.Append("</color> elements");

            return stringBuilder.ToString();
        }
    }
}