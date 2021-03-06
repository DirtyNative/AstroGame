// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'planet_instantiation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PlanetInstantiation _$PlanetInstantiationFromJson(Map<String, dynamic> json) {
  return PlanetInstantiation(
    json['planetPrefabName'] as String,
    json['atmospherePrefabName'] as String,
    json['ringPrefabName'] as String,
    json['cloudsPrefabName'] as String,
  );
}

Map<String, dynamic> _$PlanetInstantiationToJson(
        PlanetInstantiation instance) =>
    <String, dynamic>{
      'planetPrefabName': instance.planetPrefabName,
      'atmospherePrefabName': instance.atmospherePrefabName,
      'ringPrefabName': instance.ringPrefabName,
      'cloudsPrefabName': instance.cloudsPrefabName,
    };
