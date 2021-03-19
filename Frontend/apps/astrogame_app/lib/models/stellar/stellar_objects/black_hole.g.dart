// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'black_hole.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BlackHole _$BlackHoleFromJson(Map<String, dynamic> json) {
  return BlackHole()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..parentSystemId =
        const GuidConverter().fromJson(json['parentSystemId'] as String)
    ..averageDistanceToCenter =
        (json['averageDistanceToCenter'] as num)?.toDouble()
    ..rotationSpeed = (json['rotationSpeed'] as num)?.toDouble()
    ..averageTemperature = json['averageTemperature'] as int
    ..assetName = json['assetName'] as String
    ..coordinates = json['coordinates'] == null
        ? null
        : Coordinates.fromJson(json['coordinates'] as Map<String, dynamic>)
    ..resources = (json['resources'] as List)
        ?.map((e) => e == null
            ? null
            : StellarObjectResource.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$BlackHoleToJson(BlackHole instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentSystemId': const GuidConverter().toJson(instance.parentSystemId),
      'averageDistanceToCenter': instance.averageDistanceToCenter,
      'rotationSpeed': instance.rotationSpeed,
      'averageTemperature': instance.averageTemperature,
      'assetName': instance.assetName,
      'coordinates': instance.coordinates,
      'resources': instance.resources,
    };
