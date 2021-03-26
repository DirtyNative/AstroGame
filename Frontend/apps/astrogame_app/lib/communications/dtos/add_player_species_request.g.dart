// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_player_species_request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AddPlayerSpeciesRequest _$AddPlayerSpeciesRequestFromJson(
    Map<String, dynamic> json) {
  return AddPlayerSpeciesRequest()
    ..speciesId = const GuidConverter().fromJson(json['speciesId'] as String)
    ..empireName = json['empireName'] as String
    ..preferredPlanetType =
        _$enumDecodeNullable(_$PlanetTypeEnumMap, json['preferredPlanetType'])
    ..perks = (json['perks'] as List)
        ?.map((e) => e == null
            ? null
            : AddPlayerSpeciesPerkRequest.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$AddPlayerSpeciesRequestToJson(
        AddPlayerSpeciesRequest instance) =>
    <String, dynamic>{
      'speciesId': const GuidConverter().toJson(instance.speciesId),
      'empireName': instance.empireName,
      'preferredPlanetType': _$PlanetTypeEnumMap[instance.preferredPlanetType],
      'perks': instance.perks,
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
