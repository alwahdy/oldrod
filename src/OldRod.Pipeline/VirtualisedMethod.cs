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

using AsmResolver.Net.Cts;
using AsmResolver.Net.Signatures;
using OldRod.Core.Architecture;
using OldRod.Core.Ast.Cil;
using OldRod.Core.Ast.IL;
using OldRod.Core.Disassembly.ControlFlow;

namespace OldRod.Pipeline
{
    public class VirtualisedMethod
    {
        public VirtualisedMethod(uint exportId, VMExportInfo exportInfo)
        {
            ExportId = exportId;
            ExportInfo = exportInfo;
        }

        public uint ExportId
        {
            get;
            set;
        }

        public VMExportInfo ExportInfo
        {
            get;
            set;
        }

        public MethodSignature ConvertedMethodSignature
        {
            get;
            set;
        }
        
        public MethodDefinition CallerMethod
        {
            get;
            set;
        }

        public ControlFlowGraph ControlFlowGraph
        {
            get;
            set;
        }

        public ILCompilationUnit ILCompilationUnit
        {
            get;
            set;
        }

        public CilCompilationUnit CilCompilationUnit
        {
            get;
            set;
        }
        
    }
}