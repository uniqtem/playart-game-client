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

public class RandomMoveOnTerrain : MonoBehaviour {
	
	#region Variables
		public Terrain m_Terrain = null;
		
		public float m_Speed = 1.0f;
		public float m_SpeedSpread = 0.25f;
		
		public float m_MoveDistance = 3.0f;
		
		float m_currentSpeed = 0;
		float m_TimeRound = 1;
		float m_TimeCount = 0;
		Vector3	m_StartPosition;
		Vector3 m_EndPosition;
		Bounds m_LimitArea;
	#endregion
	
	// ######################################################################
	// MonoBehaviour Functions
	// ######################################################################

	#region Component Segments
	
		// Use this for initialization
		void Start () {
			// Keep first position to use for forward/backward floating
			m_StartPosition = this.transform.position;
			m_EndPosition = m_StartPosition;
			
			// Setup m_LimitArea if terrain is set
			if(m_Terrain!=null)
			{
				m_LimitArea.min = m_Terrain.transform.position;
				m_LimitArea.max = m_LimitArea.min + m_Terrain.terrainData.size;
				m_LimitArea.center = (m_LimitArea.min + m_LimitArea.max)/2;
			}
			
			// Setup for first move
			SetupNewMove();
		}
	
		// Update is called once per frame
		void Update () {
			if(m_Terrain!=null)
			{
				if(m_TimeCount>=m_TimeRound)
				{
					// Setup next move
					SetupNewMove();
				}
				else
				{
					// Move object along the way
					float CalTime = m_TimeCount/m_TimeRound;				
					transform.position = Vector3.Lerp(m_StartPosition, m_EndPosition, CalTime);
					m_TimeCount += Time.deltaTime;
					
					// Update object y position if terrain is set
					if(m_Terrain!=null)
					{
						// update object y position
						float fTerrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
						transform.position = new Vector3(transform.position.x, fTerrainHeight+m_LimitArea.min.y, transform.position.z);
					}
				}
			}
		}
	
	#endregion {Component Segments}
	
	// ######################################################################
	// Functions
	// ######################################################################

	#region Component Segments
		
		void SetupNewMove()
		{
			// Random next position
			m_StartPosition = this.transform.position;
			m_EndPosition = m_StartPosition + new Vector3(Random.Range(-m_MoveDistance,m_MoveDistance), 0, Random.Range(-m_MoveDistance,m_MoveDistance));
			
			// if Terrain is set then limit x and z position to area of Terrain
			if(m_Terrain!=null)
			{
				if(m_EndPosition.x < m_LimitArea.min.x)
					m_EndPosition.x = m_LimitArea.min.x;
				if(m_EndPosition.x > m_LimitArea.max.x)
					m_EndPosition.x = m_LimitArea.max.x;
				if(m_EndPosition.z < m_LimitArea.min.z)
					m_EndPosition.z = m_LimitArea.min.z;
				if(m_EndPosition.z > m_LimitArea.max.z)
					m_EndPosition.z = m_LimitArea.max.z;
			}
				
			// Random new Distance to go and new moving speed
			float fDistance = Vector2.Distance(new Vector2(m_StartPosition.x, m_StartPosition.z), new Vector2(m_EndPosition.x, m_EndPosition.z));
			m_currentSpeed = m_Speed + Random.Range(-m_SpeedSpread, m_SpeedSpread);
			
			// calculate time long for this move
			m_TimeRound = fDistance/m_currentSpeed;
			m_TimeCount = 0;
		}
	
	#endregion {Component Segments}
}

				