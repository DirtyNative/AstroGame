// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'planet.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Planet _$PlanetFromJson(Map<String, dynamic> json) {
  return Planet()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..parentSystemId =
        const GuidConverter().fromJson(json['parentSystemId'] as String)
    ..averageDistanceToCenter =
        (json['averageDistanceToCenter'] as num)?.toDouble()
    ..rotationSpeed = (json['rotationSpeed'] as num)?.toDouble()
    ..averageTemperature = json['averageTemperature'] as int
    ..assetName = json['assetName'] as String
    ..planetType = _$enumDecodeNullable(_$PlanetTypeEnumMap, json['planetType'])
    ..scale = (json['scale'] as num)?.toDouble()
    ..axialTilt = (json['axialTilt'] as num)?.toDouble()
    ..resources = (json['resources'] as List)
        ?.map((e) => e == null
            ? null
            : StellarObjectResource.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..hasHabitableAtmosphere = json['hasHabitableAtmosphere'] as bool
    ..order = json['order'] as int;
}

Map<String, dynamic> _$PlanetToJson(Planet instance) => <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'parentSystemId': const GuidConverter().toJson(instance.parentSystemId),
      'averageDistanceToCenter': instance.averageDistanceToCenter,
      'rotationSpeed': instance.rotationSpeed,
      'averageTemperature': instance.averageTemperature,
      'assetName': instance.assetName,
      'planetType': _$PlanetTypeEnumMap[instance.planetType],
      'scale': instance.scale,
      'axialTilt': instance.axialTilt,
      'resources': instance.resources,
      'hasHabitableAtmosphere': instance.hasHabitableAtmosphere,
      'order': instance.order,
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
