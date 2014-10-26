// Copyright (c) 2014 Gold Experience TeamDev
//
// First Fantasy for Mobile version: 1.3
// Author: Gold Experience TeamDev (http://www.ge-team.com/)
// Support: geteamdev@gmail.com
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

/*
TERMS OF USE - EASING EQUATIONS#
Open source under the BSD License.
Copyright (c)2001 Robert Penner
All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the author nor the names of contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion

/***************
* First Chest Easetypes Handler.
* Convert easetype between Hotween, Leantween and iTween tweeners.
**************/

public class FloatObject : MonoBehaviour {
	
	#region Variables
		public float m_Time = 2.0f;
		public float m_TimeSpread = 0.25f;
		public float m_HorizontalSpread = 0.25f;
		public float m_VerticalSpread = 0.25f;
		
		float m_TimeRound = 1;
		float m_TimeCount = 0;
		Vector3	m_StartPosition;
		Vector3 m_EndPosition;

		enum statMove
		{
			statMoveBegin,
			statMoveAway,
			statMoveBack
		};
		statMove m_statMove = statMove.statMoveBegin;
	
	#endregion
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################

	#region Component Segments
	
		// Use this for initialization
		void Start () {
			
			// Keep original position for floating forward/backward
			m_StartPosition = this.transform.localPosition;
			
			// Setup for first move
			SetupNewMove();
		}
	
		// Update is called once per frame
		void Update () {
			if(m_TimeCount>=m_TimeRound)
			{
				// Setup next move
				SetupNewMove();
			}
			else
			{
				float CalTime = m_TimeCount/m_TimeRound;		
				// Floating forward
				if(m_statMove==statMove.statMoveAway)
				{
					transform.localPosition = Vector3.Lerp(m_StartPosition, m_EndPosition, CalTime);
				}
				// Floating backward
				else
				{
					transform.localPosition = Vector3.Lerp(m_EndPosition, m_StartPosition, CalTime);				
				}
				m_TimeCount += Time.deltaTime;
			}
		}
	
	#endregion {Component Segments}	
	
	// ######################################################################
	// Functions Functions
	// ######################################################################

	#region Functions
		
		void SetupNewMove()
		{
			// Random round time
			m_TimeRound = m_Time + Random.Range(-m_TimeSpread,m_TimeSpread);
			m_TimeCount = 0;		
			
			// Check for update float state and random next position
			if(m_statMove==statMove.statMoveAway)
			{
				m_statMove = statMove.statMoveBack;
			}
			else if(m_statMove==statMove.statMoveBack || m_statMove==statMove.statMoveBegin)
			{
				// Random next position
				m_EndPosition = m_StartPosition + new Vector3(Random.Range(-m_HorizontalSpread,m_HorizontalSpread), Random.Range(-m_VerticalSpread,m_VerticalSpread), Random.Range(-m_HorizontalSpread,m_HorizontalSpread));
				m_statMove = statMove.statMoveAway;
			}
		}
	
	#endregion {Functions}
}

				