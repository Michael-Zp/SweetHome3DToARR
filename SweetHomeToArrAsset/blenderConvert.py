import bpy
import sys
from mathutils import Matrix, Vector

argv = sys.argv
argv = argv[argv.index("--") + 1:] # get all args after "--"

obj_in = argv[0]
fbx_out = argv[1]

context = bpy.context
scene = context.scene

for c in scene.collection.children:
    scene.collection.children.unlink(c)

bpy.ops.import_scene.obj(filepath=obj_in, axis_forward='-Z', axis_up='Y')

# Try to center, but did not work
# mesh_obs = [o for o in scene.objects if o.type == 'MESH']

# for o in mesh_obs:
#     me = o.data
#     mw = o.matrix_world
#     origin = sum((v.co for v in me.vertices), Vector()) / len(me.vertices)

#     T = Matrix.Translation(-origin)
#     me.transform(T)
#     mw.translation = mw @ origin

bpy.ops.export_scene.fbx(filepath=fbx_out, axis_forward='-Z', axis_up='Y')