using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BresenhamThingy : IEnumerable {
		Vector2 start;
		Vector2 end;
		float steps = 1;
		
		public BresenhamThingy( Vector2 path_start, Vector2 path_end )
		{
			start = path_start;
			end = path_end;
			steps = 1;
		}
		public BresenhamThingy( Vector2 path_start, Vector2 path_end, float path_steps )
		{
			steps = path_steps;
			start = path_start * steps;
			end = path_end * steps;
		}
		
		public IEnumerator GetEnumerator()
		{
			Vector2 result;
			
		int xd, yd;
		int x, y;
		int ax, ay;
		int sx, sy;
		int dx, dy;
			
			dx = (int)(end.x - start.x);
			dy = (int)(end.y - start.y);
			
			
			ax = Mathf.Abs( dx ) << 1;
			ay = Mathf.Abs( dy ) << 1;
			
			
			sx = (int)Mathf.Sign( (float) dx );
			sy = (int)Mathf.Sign( (float) dy );
			
			
			x = (int)start.x;
			y = (int)start.y;
			
			
			if( ax >= ay )// x dominant
			{
				yd = ay - ( ax >> 1 );

				for( ; ; )
				{
					result.x = (int)( x / steps );
					result.y = (int)( y / steps );
					yield return result;
					
					if( x == (int)end.x )
						yield break;
					
					if( yd >= 0 )
					{
						y += sy;
						yd -= ax;
					}
									
					x += sx;
					yd += ay;
				}
			}
			else if( ay >=  ax ) // y dominant
			{
				xd = ax - ( ay >> 1 );
				
				for( ; ; )
				{
					result.x = (int)( x / steps );
					result.y = (int)( y / steps );

					yield return result;
					
					if( y == (int)end.y )
						yield break;
					
					if( xd >= 0 )
					{
						x += sx;
						xd -= ay;
					}
					
					
					
					y += sy;
					xd += ax;
			
				}
			}

		}
	}