using System;
using System.Drawing;
using System.Numerics;

namespace ImGuizmoNET
{
    public static unsafe partial class ImGuizmo
    {
        public static bool Manipulate(ref Matrix4x4 view, ref Matrix4x4 projection, OPERATION operation, MODE mode,
            ref Matrix4x4 matrix)
        {
            fixed (void* viewPtr = &view)
            {
                fixed (void* projectionPtr = &projection)
                {
                    fixed (void* matrixPtr = &matrix)
                    {
                        bool set = ImGuizmoNative.ImGuizmo_Manipulate((float*)viewPtr, (float*)projectionPtr, operation, mode,
                            (float*)matrixPtr, null, null, null, null) > 0;
                        return set;
                    }
                }
            }
        }

        public static bool Manipulate(ref Matrix4x4 view, ref Matrix4x4 projection, OPERATION operation, MODE mode,
            ref Matrix4x4 matrix, ref Matrix4x4 deltaMatrix, ReadOnlySpan<float> snap)
        {
            fixed (void* viewPtr = &view)
            {
                fixed (void* projectionPtr = &projection)
                {
                    fixed (void* matrixPtr = &matrix)
                    {
                        fixed (void* deltaMatrixPtr = &deltaMatrix)
                        {
                            fixed (float* snapPtr = snap)
                            {
                                bool set = ImGuizmoNative.ImGuizmo_Manipulate((float*)viewPtr, (float*)projectionPtr, operation, mode,
                                    (float*)matrixPtr, (float*)deltaMatrixPtr, snapPtr, null, null) > 0;
                                return set;
                            }
                        }
                    }
                }
            }
        }
        
        public static void DrawGrid(ref Matrix4x4 view, ref Matrix4x4 projection, ref Matrix4x4 matrix,
            float gridSize)
        {
            fixed (void* viewPtr = &view)
            {
                fixed (void* projectionPtr = &projection)
                {
                    fixed (void* matrixPtr = &matrix)
                    {
                        ImGuizmoNative.ImGuizmo_DrawGrid((float*)viewPtr, (float*)projectionPtr, (float*)matrixPtr, gridSize);
                    }
                }
            }
        }
        
        public static void ViewManipulate(ref Matrix4x4 view, float length, Vector2 position, Vector2 size,
            Color backgroundColor)
        {
            ViewManipulate(ref view, length, position, size, (uint)backgroundColor.ToArgb());
        }
        
        public static void ViewManipulate(ref Matrix4x4 view, float length, Vector2 position, Vector2 size,
            uint backgroundColor)
        {
            fixed (void* viewPtr = &view)
            {
                ImGuizmoNative.ImGuizmo_ViewManipulate_Float((float*)viewPtr, length, position, size, backgroundColor);
            }
        }

        public static void ViewManipulate(ref Matrix4x4 view, ref Matrix4x4 projection, OPERATION operation, MODE mode,
            ref Matrix4x4 matrix, float length, Vector2 position, Vector2 size,
            Color backgroundColor)
        {
            ViewManipulate(ref view, ref projection, operation, mode, ref matrix, length, position, size, (uint)backgroundColor.ToArgb());
        }
        
        public static void ViewManipulate(ref Matrix4x4 view, ref Matrix4x4 projection, OPERATION operation, MODE mode, ref Matrix4x4 matrix, float length, Vector2 position, Vector2 size,
            uint backgroundColor)
        {
            fixed (void* viewPtr = &view)
            {
                fixed (void* projectionPtr = &projection)
                {
                    fixed (void* matrixPtr = &matrix)
                    {
                        ImGuizmoNative.ImGuizmo_ViewManipulate_FloatPtr((float*)viewPtr, (float*)projectionPtr, operation, mode, (float*)matrixPtr, length, position, size, backgroundColor);
                    }
                }
            }
        }

        public static void DecomposeMatrixToComponents(ref Matrix4x4 matrix, ref Vector3 translation, ref Vector3 rotation, ref Vector3 scale)
        {
            fixed (void* matrixPtr = &matrix)
            {
                fixed (void* translationPtr = &translation)
                {
                    fixed (void* rotationPtr = &rotation)
                    {
                        fixed (void* scalePtr = &scale)
                        {
                            ImGuizmoNative.ImGuizmo_DecomposeMatrixToComponents((float*)matrixPtr, (float*)translationPtr, (float*)rotationPtr, (float*)scalePtr);
                        }
                    }
                }
            }
        }
    }
}