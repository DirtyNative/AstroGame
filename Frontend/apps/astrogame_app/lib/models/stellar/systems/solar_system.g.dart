// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'solar_system.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SolarSystem _$SolarSystemFromJson(Map<String, dynamic> json) {
  return SolarSystem()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..centerObjects = (json['centerObjects'] as List)
        ?.map((e) =>
            const StellarObjectConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..satellites = (json['satellites'] as List)
        ?.map((e) =>
            const StellarSystemConverter().fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..name = json['name'] as String
    ..coordinates = json['coordinates'] == null
        ? null
        : Coordinates.fromJson(json['coordinates'] as Map<String, dynamic>)
    ..isGenerated = json['isGenerated'] as bool;
}

Map<String, dynamic> _$SolarSystemToJson(SolarSystem instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'centerObjects': instance.centerObjects
          ?.map(const StellarObjectConverter().toJson)
          ?.toList(),
      'satellites': instance.satellites
          ?.map(const StellarSystemConverter().toJson)
          ?.toList(),
      'name': instance.name,
      'coordinates': instance.coordinates,
      'isGenerated': instance.isGenerated,
    };
