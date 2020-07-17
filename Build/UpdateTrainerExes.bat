REM This file is part of TkMemory.Application.

REM TkMemory.Application is free software. You can redistribute it and/or
REM modify it under the terms of the GNU General Public License as published
REM by the Free Software Foundation, either version 3 of the License or (at
REM your option) any later version.

REM TkMemory.Application is distributed in the hope that it will be useful
REM but WITHOUT ANY WARRANTY, without even the implied warranty of MERCHANTABILITY
REM or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
REM more details.

REM You should have received a copy of the GNU General Public License
REM along with TkMemory.Application. If not, please refer to:
REM https://www.gnu.org/licenses/gpl-3.0.en.html

xcopy /s/Y %~dp0..\TkMemory.Mage\bin\%1\Mage.exe %~dp0..\ProjectArtifacts
xcopy /s/Y %~dp0..\TkMemory.Poet\bin\%1\Poet.exe %~dp0..\ProjectArtifacts
xcopy /s/Y %~dp0..\TkMemory.Rogue\bin\%1\Rogue.exe %~dp0..\ProjectArtifacts
xcopy /s/Y %~dp0..\TkMemory.Warrior\bin\%1\Warrior.exe %~dp0..\ProjectArtifacts
xcopy /s/Y %~dp0..\TkMemory.AutoFollow\bin\%1\AutoFollow.exe %~dp0..\ProjectArtifacts
