// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vector_3.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Vector3 _$Vector3FromJson(Map<String, dynamic> json) {
  return Vector3()
    ..x = (json['x'] as num)?.toDouble()
    ..y = (json['y'] as num)?.toDouble()
    ..z = (json['z'] as num)?.toDouble();
}

Map<String, dynamic> _$Vector3ToJson(Vector3 instance) => <String, dynamic>{
      'x': instance.x,
      'y': instance.y,
      'z': instance.z,
    };
