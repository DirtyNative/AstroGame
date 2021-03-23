// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'player_species.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PlayerSpecies _$PlayerSpeciesFromJson(Map<String, dynamic> json) {
  return PlayerSpecies()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..speciesId = const GuidConverter().fromJson(json['speciesId'] as String)
    ..empireName = json['empireName'] as String
    ..preferredPlanetType =
        _$enumDecodeNullable(_$PlanetTypeEnumMap, json['preferredPlanetType'])
    ..species = json['species'] == null
        ? null
        : Species.fromJson(json['species'] as Map<String, dynamic>);
}

Map<String, dynamic> _$PlayerSpeciesToJson(PlayerSpecies instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'speciesId': const GuidConverter().toJson(instance.speciesId),
      'empireName': instance.empireName,
      'preferredPlanetType': _$PlanetTypeEnumMap[instance.preferredPlanetType],
      'species': instance.species,
    };

T _$enumDecode<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    throw ArgumentError('A value must be provided. Supported values: '
        '${enumValues.values.join(', ')}');
  }

  final value = enumValues.entries
      .singleWhere((e) => e.value == source, orElse: () => null)
      ?.key;

  if (value == null && unknownValue == null) {
    throw ArgumentError('`$source` is not one of the supported values: '
        '${enumValues.values.join(', ')}');
  }
  return value ?? unknownValue;
}

T _$enumDecodeNullable<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    return null;
  }
  return _$enumDecode<T>(enumValues, source, unknownValue: unknownValue);
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
