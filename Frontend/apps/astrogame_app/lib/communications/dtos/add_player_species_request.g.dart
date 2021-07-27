// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_player_species_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AddPlayerSpeciesRequest _$AddPlayerSpeciesRequestFromJson(
    Map<String, dynamic> json) {
  return AddPlayerSpeciesRequest(
    const GuidConverter().fromJson(json['speciesId'] as String),
    json['empireName'] as String,
    _$enumDecode(_$PlanetTypeEnumMap, json['preferredPlanetType']),
    (json['perks'] as List<dynamic>)
        .map((e) =>
            AddPlayerSpeciesPerkRequest.fromJson(e as Map<String, dynamic>))
        .toList(),
  );
}

Map<String, dynamic> _$AddPlayerSpeciesRequestToJson(
        AddPlayerSpeciesRequest instance) =>
    <String, dynamic>{
      'speciesId': const GuidConverter().toJson(instance.speciesId),
      'empireName': instance.empireName,
      'preferredPlanetType': _$PlanetTypeEnumMap[instance.preferredPlanetType],
      'perks': instance.perks,
    };

K _$enumDecode<K, V>(
  Map<K, V> enumValues,
  Object? source, {
  K? unknownValue,
}) {
  if (source == null) {
    throw ArgumentError(
      'A value must be provided. Supported values: '
      '${enumValues.values.join(', ')}',
    );
  }

  return enumValues.entries.singleWhere(
    (e) => e.value == source,
    orElse: () {
      if (unknownValue == null) {
        throw ArgumentError(
          '`$source` is not one of the supported values: '
          '${enumValues.values.join(', ')}',
        );
      }
      return MapEntry(unknownValue, enumValues.values.first);
    },
  ).key;
}

const _$PlanetTypeEnumMap = {
  PlanetType.volcano: 0,
  PlanetType.desert: 1,
  PlanetType.continental: 2,
  PlanetType.ocean: 3,
  PlanetType.rock: 4,
  PlanetType.gas: 5,
  PlanetType.ice: 6,
  PlanetType.gaia: 7,
};
