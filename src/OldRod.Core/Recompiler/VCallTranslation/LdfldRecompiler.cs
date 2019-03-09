// Project OldRod - A KoiVM devirtualisation utility.
// Copyright (C) 2019 Washi
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.

using AsmResolver.Net.Cil;
using AsmResolver.Net.Signatures;
using OldRod.Core.Ast.Cil;
using OldRod.Core.Ast.IL;
using OldRod.Core.Disassembly.Inference;

namespace OldRod.Core.Recompiler.VCallTranslation
{
    public class LdfldRecompiler : IVCallRecompiler
    {
        public CilExpression Translate(RecompilerContext context, ILVCallExpression expression)
        {
            var metadata = (FieldMetadata) expression.Metadata;
            bool hasThis = metadata.Field.Signature.HasThis;

            var result = new CilInstructionExpression(hasThis ? CilOpCodes.Ldfld : CilOpCodes.Ldsfld, metadata.Field);

            // Recompile object expression.
            if (hasThis)
            {
                var objectExpression = expression.Arguments[expression.Arguments.Count - 1];
                result.Arguments.Add((CilExpression) objectExpression.AcceptVisitor(context.Recompiler));
            }

            result.ExpressionType = ((FieldSignature) metadata.Field.Signature).FieldType;
            
            return result;
        }
        
    }
}